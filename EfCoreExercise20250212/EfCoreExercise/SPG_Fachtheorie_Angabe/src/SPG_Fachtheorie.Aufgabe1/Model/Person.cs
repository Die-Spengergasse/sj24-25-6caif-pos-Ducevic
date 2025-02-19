using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Person
    {
        // Datenfelder mit Längenbegrenzungen
        [MaxLength(255)]
        public string Firstname { get; set; }

        [MaxLength(255)]
        public string Lastname { get; set; }

        [MaxLength(255)]
        public string Accountname { get; set; }

        // Primärschlüssel
        public int Id { get; set; }

        // EF Core Konstruktor
        protected Person() { }

        // Domain-Konstruktor mit Null-Checks
        public Person(string firstname, string lastname, string accountname)
        {
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Accountname = accountname ?? throw new ArgumentNullException(nameof(accountname));
        }
    }
}
