using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class DamageReport
    {
        // Primärschlüssel
        public int Id { get; set; }

        // Navigationseigenschaften mit erforderlichen Fremdschlüsseln
        [Required]
        public Damage Damage { get; set; }

        [Required]
        public Person Reporter { get; set; }

        // Zeitstempel mit Defaultwert
        [Required]
        public DateTime DateTime { get; set; }

        // EF Core Konstruktor
        protected DamageReport() { }

        // Domain-Konstruktor
        public DamageReport(Damage damage, Person reporter, DateTime dateTime)
        {
            Damage = damage ?? throw new ArgumentNullException(nameof(damage));
            Reporter = reporter ?? throw new ArgumentNullException(nameof(reporter));
            DateTime = dateTime;
        }
    }
}
