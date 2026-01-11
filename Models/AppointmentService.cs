using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raul_Moldovan_Medii.Models
{
    public class AppointmentService
    {
        public int ID { get; set; }

        [Required]
        public int AppointmentID { get; set; }
        public Appointment? Appointment { get; set; }

        [Required]
        public int ServiceTypeID { get; set; }
        public ServiceType? ServiceType { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(8, 2)")]
        [Range(0, 100000)]
        [Display(Name = "Preț la programare")]
        public decimal PriceAtBooking { get; set; }
    }
}
