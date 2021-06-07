using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Models;

namespace DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            using (var db = new Models.CompanyContext())
            {
                Console.WriteLine("Applying schemas");
                db.Database.Migrate();
                Console.WriteLine("Retrieving users from db");
                var usersInDB = db.Users.Count();
                Console.WriteLine($"Users in database: {usersInDB}");
                Console.WriteLine($"Inserting 100 users ...");
                for (int i = 0; i < 100; i++)
                {
                    db.Users.Add(new User {FirstName = $"First {i}", Surname = $"Surname{i}"});
                }

                var insertedUsers = db.SaveChanges();
                Console.WriteLine($"Finished inserting users ({insertedUsers})");
            }
            Console.ReadKey();
        }
    }
}
