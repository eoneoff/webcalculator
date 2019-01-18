using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoCalculatorRepository
{
    public class Queries
    {
        protected readonly string loadHistoryQuery = @"SELECT Expression FROM Operations AS O
                                    INNER JOIN Users AS U
                                    ON O.UserId = U.Id
                                    WHERE U.Ip = @ip
                                    AND O.TimeOfOperation > DATEADD(day, -1, GETDATE())
                                    ORDER BY O.TimeOfOperation";

        protected readonly string saveRecord = "save_operation";

        protected readonly string existCheck = "SELECT database_id FROM sys.databases WHERE Name = 'CalculatorHistoryDb'";
        protected readonly string createDatabase = "CREATE DATABASE CalculatorHistoryDb";
        protected readonly string setCompartibilityLevel = "ALTER DATABASE CalculatorHistoryDb SET COMPATIBILITY_LEVEL = 110";

        protected readonly string createUsersTable="CREATE TABLE Users (" +
                                                    "Id int IDENTITY(1,1) PRIMARY KEY," +
                                                    "Ip nvarchar(40) NOT NULL)";
        protected readonly string setUserIpIndex = "CREATE INDEX idx_user_ip " +
                                                    "ON Users(Ip)";

        protected readonly string createOperationsTable = "CREATE TABLE Operations(" +
                                                            "Id int IDENTITY (1,1) PRIMARY KEY," +
                                                            "Expression nvarchar(MAX) NOT NULL," +
                                                            "UserId int NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE," +
                                                            "TimeOfOperation datetime NOT NULL)";
        protected readonly string setOperationUserIndex = "CREATE INDEX idx_operation_userid " +
                                                            "ON Operations (UserId)";
        protected readonly string setOperationsTimeIndex = "CREATE INDEX idx_operation_time " +
                                                            "ON Operations(TimeOfOperation)";

        protected readonly string saveOperationProcedure =
            "CREATE PROCEDURE save_operation @ip nvarchar(40), @expression nvarchar(MAX)" +
            "AS " +
            "BEGIN " +
                "DECLARE @userId int " +
                "IF EXISTS (SELECT 1 FROM Users WHERE Users.Ip = @ip) " +
                    "SET @userId = (SELECT Id FROM Users WHERE Ip = @ip) " +
                "ELSE " +
                "BEGIN " +
                    "INSERT INTO Users (Ip) " +
                    "VALUES (@ip) " +
                    "SET @userId = @@IDENTITY " +
                "END " +
                "INSERT INTO Operations (Expression, UserId, TimeOfOperation) " +
                "VALUES(@expression, @userId, GETDATE()) " +
            "END";
    }
}
