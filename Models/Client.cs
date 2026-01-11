using System.ComponentModel.DataAnnotations;

namespace Raul_Moldovan_Medii.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Prenume")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [Display(Name = "Nume")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Nume complet")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Car>? Cars { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
