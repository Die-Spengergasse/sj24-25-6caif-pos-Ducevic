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

        [Fact]
        public void CreateDatabaseTest()
        {
            using var db = GetEmptyDbContext();
            //Assert.True(db.Employees.Count() == 0);
        }

        [Fact]
        public void AddEmployeeSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            //ARRANGE
            using var db = GetEmptyDbContext();
            var employee = new Employee("FN", "LN", "ACC", "B5.18");
            //ACT
            db.Employees.Add(employee);
            db.SaveChanges();
            //ASSERT
            db.ChangeTracker.Clear();

        }

        [Fact]
        public void AddDamageWithReportSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            // ARRANGE
            using var db = GetEmptyDbContext();
            var roomnumber = new Roomnumber("A", "3", 15);
            var room = new Room(roomnumber, "WC");
            var damage = new Damage(room, "Benutztes Kondom gefunden."); 
            db.Damages.Add(damage);
            db.SaveChanges();

            var reporter = new Person("FN", "LN", "ACC");
            var report = new DamageReport(damage, reporter, new DateTime(2025, 2, 14, 9, 0, 0));

            // ACT
            db.Damages.Add(damage);
            db.SaveChanges();
            db.DamageReports.Add(report);
            db.SaveChanges();

            // ASSERT
            db.ChangeTracker.Clear();
            var damageReportFromDb = db.DamageReports.First();
            Assert.True(damageReportFromDb.Id != default); 
        }

        [Fact]
        public void AddRepairationSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            throw new NotImplementedException();

            using var db = GetEmptyDbContext();
            var roomnumber = new Roomnumber("A", "3", 15);
            var room = new Room(room, "WC");
            var damage = new Damage(room, "Benutztes Kondom");
            var repairer = new Employee("FN", "LN", "ACC", "B5.18");
            var repairer = new Repairation(damage, repairer, new DateTime(2025, 2, 15, 10, 0,0),"wurde weitergeleitet");
        }
    }
}