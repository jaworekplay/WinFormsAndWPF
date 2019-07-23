using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    //Setting up
    //https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
    //and
    //https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext

    public class CompanyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True"
                                , providerOptions => providerOptions.CommandTimeout(60));
        }
    }
}
