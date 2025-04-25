using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public abstract class Employee
    {
        protected Employee() { }

        public Employee(int registrationNumber, string firstName, string lastName, Address? address)
        {
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegistrationNumber { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public Address? Address { get; set; }

        public DateTime? LastLogin { get; set; }

        public string Type { get; set; } = null!;

        public List<Payment> Payments { get; } = new();
    }
}
