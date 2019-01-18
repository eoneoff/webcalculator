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
        public CalculatorDbContext():base("CalculatorHistoryDb")
        {
            Database.SetInitializer(
                new CreateDatabaseIfNotExists<CalculatorDbContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u=>u.Ip);
            modelBuilder.Entity<Operation>().HasIndex(o => o.UserId);
            modelBuilder.Entity<Operation>().HasIndex(o => o.TimeOfOperation);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
