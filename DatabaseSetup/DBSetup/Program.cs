﻿using System;
using System.Linq;

namespace DBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new Models.CompanyContext())
            {
                var usersInDB = db.Users.Count();
                Console.Write($"Users in database: {usersInDB}");
            }
        }
    }
}
