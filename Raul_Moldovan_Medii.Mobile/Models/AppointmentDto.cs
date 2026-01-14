using System;
using System.Collections.Generic;
using System.Text;
namespace Raul_Moldovan_Medii.Mobile.Models
{
    public class AppointmentDto
    {
        public int ID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int Status { get; set; }

        public ClientDto? Client { get; set; }
        public CarDto? Car { get; set; }
        public MechanicDto? Mechanic { get; set; }

     
        public string DataOra => AppointmentDateTime.ToString("dd.MM.yyyy HH:mm");
        public string ClientText => Client is null ? "-" : $"{Client.FirstName} {Client.LastName}";
        public string MasinaText => Car is null ? "-" : $"{Car.PlateNumber} - {Car.Make} {Car.Model}";
        public string MecanicText => Mechanic is null ? "-" : $"{Mechanic.FirstName} {Mechanic.LastName}";
    }

    public class ClientDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class CarDto
    {
        public int ID { get; set; }
        public string PlateNumber { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
    }

    public class MechanicDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
    public class CreateAppointmentRequest
    {
        public DateTime AppointmentDateTime { get; set; }
        public int Status { get; set; } = 0; // Pending
        public int ClientID { get; set; }
        public int CarID { get; set; }
        public int? MechanicID { get; set; }
    }

    public class CreateAppointmentResponse
    {
        public int Id { get; set; }
    }

}

