using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raul_Moldovan_Medii.Models
{
    public class ServiceType
    {
        public int ID { get; set; }

        [Required, StringLength(80)]
        [Display(Name = "Serviciu")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8, 2)")]
        [Range(0, 100000)]
        [Display(Name = "Preț de bază")]
        public decimal BasePrice { get; set; }

        [Range(5, 1440)]
        [Display(Name = "Durată (minute)")]
        public int DurationMinutes { get; set; }

        public ICollection<AppointmentService>? AppointmentServices { get; set; }
    }
}
