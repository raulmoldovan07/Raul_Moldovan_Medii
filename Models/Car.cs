using System.ComponentModel.DataAnnotations;

namespace Raul_Moldovan_Medii.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17)]
        [Display(Name = "VIN")]
        public string Vin { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        [Display(Name = "Număr înmatriculare")]
        public string PlateNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Marcă")]
        public string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Model")]
        public string Model { get; set; } = string.Empty;

        [Range(1950, 2100)]
        [Display(Name = "An")]
        public int Year { get; set; }

      
        [Display(Name = "Mașină")]
        public string CarDisplay => $"{PlateNumber} - {Make} {Model}";

        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client? Client { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
