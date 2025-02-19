using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Model;

namespace SPG_Fachtheorie.Aufgabe1.Infrastructure
{
    public class DamageContext : DbContext
    {
        // DbSets für alle Entitäten
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<DamageReport> DamageReports { get; set; }
        public DbSet<Repairation> Repairations { get; set; }

        public DamageContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().OwnsOne(r => r.Roomnumber);

            // Unique-Constraint für Accountname
            modelBuilder.Entity<Person>()
                .HasIndex(p => p.Accountname)
                .IsUnique();

            // TPH-Vererbung konfigurieren
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Person>("Person")
                .HasValue<Employee>("Employee");

            // Enum als String speichern
            modelBuilder.Entity<Damage>()
                .Property(d => d.Status)
                .HasConversion<string>();

            // Beziehung DamageReport -> Damage
            modelBuilder.Entity<DamageReport>()
                .HasOne(dr => dr.Damage)
                .WithMany(d => d.Reports)
                .OnDelete(DeleteBehavior.Cascade);

            // Beziehung Repairation -> Damage
            modelBuilder.Entity<Repairation>()
                .HasOne(r => r.Damage)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
