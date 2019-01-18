using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoCalculatorRepository
{
    public class CalculatorRepository : Queries, ICalculatorRepository.ICalculatorRepository
    {
        private readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CalculatorHistoryDb"].ConnectionString);

        private static bool firstStart = true;

        public CalculatorRepository()
        {
            if (firstStart)
            {
                CreateDatabase();
                firstStart = false;
            }
        }

        public async Task<IEnumerable<string>> GetOperations(string ip)
        {
            try
            {
                conn.Open();
                IEnumerable<string> expressions = new List<string>();
                SqlCommand cmd = new SqlCommand(loadHistoryQuery, conn);
                cmd.Parameters.AddWithValue("@ip", ip);
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                expressions = rdr.Cast<IDataRecord>().Select(r => r["Expression"] as string).ToList();
                return expressions;
            }
            finally
            {
                conn?.Close();
            }
        }

        public async Task SaveOperation(string ip, string expression)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(saveRecord, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ip", ip);
                cmd.Parameters.AddWithValue("@expression", expression);
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                conn?.Close();
            }
        }

        private void CreateDatabase()
        {
            SqlConnection checkConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDbServer"].ConnectionString);
            try
            {
                checkConn.Open();
                SqlCommand create = new SqlCommand(existCheck, checkConn);
                var exists = create.ExecuteScalar();
                if(exists == null)
                {
                    create.CommandText =$"{createDatabase};" +
                                        $"{setCompartibilityLevel};";
                    create.ExecuteNonQuery();

                    checkConn.Close();

                    conn.Open();
                    SqlCommand setBase = new SqlCommand(
                        $"{createUsersTable};" +
                        $"{setUserIpIndex};", 
                        conn);
                    setBase.ExecuteNonQuery();
                    setBase.CommandText =$"{createOperationsTable};" +
                                        $"{setOperationUserIndex};" +
                                        $"{setOperationsTimeIndex};";
                    setBase.ExecuteNonQuery();
                    setBase.CommandText = saveOperationProcedure;
                    setBase.ExecuteNonQuery();
                }
            }
            finally
            {
                checkConn?.Close();
                conn?.Close();
            }
        }
    }
}
