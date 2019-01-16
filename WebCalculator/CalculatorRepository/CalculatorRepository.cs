using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnection;
using ICalculatorRepository;
using Model;

namespace CalculatorRepository
{
    public class CalculatorRepository : ICalculatorRepository.ICalculatorRepository
    {
        private CalculatorDbContext db = new CalculatorDbContext();

        public async Task<IEnumerable<string>> GetOperations(string ip)
        {
            return await db.Operations.Where(o => o.UserId == 
                db.Users.FirstOrDefault(u=>u.Ip == ip).Id &&
                o.TimeOfOperation > DateTime.Now.AddDays(-1))
                .Select(o => o.Expresssion).ToListAsync();
        }

        public async Task SaveOperation(string ip, string expression)
        {
            User user = db.Users.FirstOrDefault(u => u.Ip == ip) ?? new User();
            if(user.Id == 0)
            {
                user.Ip = ip;
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }

            Operation operation = new Operation
            {
                UserId = user.Id,
                Expresssion = expression,
                TimeOfOperation = DateTime.Now
            };

            db.Operations.Add(operation);
            await db.SaveChangesAsync();
        }
    }
}
