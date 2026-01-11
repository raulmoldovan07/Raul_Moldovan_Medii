using System.ComponentModel.DataAnnotations;

namespace Raul_Moldovan_Medii.Models
{
    public enum AppointmentStatus
    {
        [Display(Name = "În așteptare")]
        Pending = 0,

        [Display(Name = "Confirmată")]
        Confirmed = 1,

        [Display(Name = "Finalizată")]
        Done = 2,

        [Display(Name = "Anulată")]
        Cancelled = 3
    }



    public class Appointment
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Data și ora")]
        public DateTime AppointmentDateTime { get; set; }

        [Display(Name = "Status")]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        [Display(Name = "Appointment")]
        public string AppointmentDisplay => $"{AppointmentDateTime:dd.MM.yyyy HH:mm}";


        
        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client? Client { get; set; }

        [Required]
        [Display(Name = "Mașină")]
        public int CarID { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "Mecanic")]
        public int? MechanicID { get; set; }
        public Mechanic? Mechanic { get; set; }

        public ICollection<AppointmentService>? AppointmentServices { get; set; }
    }

}
