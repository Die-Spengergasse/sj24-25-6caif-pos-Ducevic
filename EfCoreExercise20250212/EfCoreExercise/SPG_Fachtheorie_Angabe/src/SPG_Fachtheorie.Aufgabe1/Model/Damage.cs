using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Damage
    {
        protected Damage() { }

        public Damage(Room room, string description)
        {
            Room = room;
            Description = description;
            Status = RepairStatus.Reported; // Standardstatus setzen
        }

        public int Id { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")] // Speichert Enum als String
        public RepairStatus Status { get; set; }
    }
}
