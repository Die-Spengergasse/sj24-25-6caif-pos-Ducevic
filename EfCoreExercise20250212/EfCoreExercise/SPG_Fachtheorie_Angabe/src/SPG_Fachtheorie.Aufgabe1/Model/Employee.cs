using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Employee : Person
    {
        // MaxLength für Office gemäß Aufgabenstellung
        [MaxLength(20)]
        public string Office { get; set; }

        // EF Core Konstruktor korrigiert
        protected Employee() { }

        // Domain-Konstruktor mit Basisparametern
        public Employee(
            string firstname,
            string lastname,
            string accountname,
            string office)
            : base(firstname, lastname, accountname)
        {
            Office = office;
        }
    }
}
