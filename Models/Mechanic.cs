using System.ComponentModel.DataAnnotations;

namespace Raul_Moldovan_Medii.Models
{
    public class Mechanic
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Prenume")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [Display(Name = "Nume")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Specializare")]
        public string? Specialization { get; set; }

        [Display(Name = "Nume complet")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
