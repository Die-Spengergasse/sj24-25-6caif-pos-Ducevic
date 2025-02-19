using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Test;
using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Roomnumber
    {
        // TODO: Add your properties and constructors
        public Roomnumber(string building, string floor, int number)
        {
            Building = building;
            Floor = floor;
            Number = number;
        }


        public string Building { get; set; }
        public string Floor { get; set; }
        public int Number { get; set; }
    }
}
Aufgabe1Test.cs
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System;
using System.Linq;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe1.Test
{
    [Collection("Sequential")]
    public class Aufgabe1Test
    {
        private DamageContext GetEmptyDbContext()
        {
            // Database created in Debug\net8.0\damages.db
            var options = new DbContextOptionsBuilder()
                .UseSqlite(@"Data Source=damages.db")
                .Options;

            var db = new DamageContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        
        public void CreateDatabaseTest()
        {
            using var db = GetEmptyDbContext();
            //Assert.True(db.Employees.Count() == 0);
        }

       
        public void AddEmployeeSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            throw new NotImplementedException();
        }

        public void AddDamageWithReportSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            throw new NotImplementedException();
        }

        public void AddRepairationSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            throw new NotImplementedException();
        }
    }
}