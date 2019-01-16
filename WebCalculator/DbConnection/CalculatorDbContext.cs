using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext():base("CalculatorDb")
        {
            Database.SetInitializer(
                new CreateDatabaseIfNotExists<CalculatorDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
