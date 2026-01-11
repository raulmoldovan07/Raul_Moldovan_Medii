using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsApiController : ControllerBase
    {
        private readonly ServiceAutoContext _context;

        public AppointmentsApiController(ServiceAutoContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var data = await _context.Appointment
                .AsNoTracking()
                .Include(a => a.Client)
                .Include(a => a.Car)
                .Include(a => a.Mechanic)
                .OrderByDescending(a => a.AppointmentDateTime)
                .Select(a => new AppointmentDto
                {
                    ID = a.ID,
                    AppointmentDateTime = a.AppointmentDateTime,
                    Status = (int)a.Status,

                    Client = a.Client == null ? null : new ClientDto
                    {
                        ID = a.Client.ID,
                        FirstName = a.Client.FirstName,
                        LastName = a.Client.LastName,
                        Email = a.Client.Email
                    },

                    Car = a.Car == null ? null : new CarDto
                    {
                        ID = a.Car.ID,
                        PlateNumber = a.Car.PlateNumber,
                        Make = a.Car.Make,
                        Model = a.Car.Model
                    },

                    Mechanic = a.Mechanic == null ? null : new MechanicDto
                    {
                        ID = a.Mechanic.ID,
                        FirstName = a.Mechanic.FirstName,
                        LastName = a.Mechanic.LastName
                    }
                })
                .ToListAsync();

            return Ok(data);
        }

        
        [HttpPost]
        public async Task<ActionResult<CreateAppointmentResponse>> Create([FromBody] CreateAppointmentRequest req)
        {
            if (req == null)
                return BadRequest("Body lipsă.");

            if (req.ClientID <= 0) return BadRequest("ClientID invalid.");
            if (req.CarID <= 0) return BadRequest("CarID invalid.");
            if (req.AppointmentDateTime == default) return BadRequest("Data/ora invalidă.");

            
            if (!await _context.Client.AnyAsync(x => x.ID == req.ClientID))
                return BadRequest("Client inexistent.");

            if (!await _context.Car.AnyAsync(x => x.ID == req.CarID))
                return BadRequest("Mașină inexistentă.");

            if (req.MechanicID.HasValue && !await _context.Mechanic.AnyAsync(x => x.ID == req.MechanicID.Value))
                return BadRequest("Mecanic inexistent.");

           
            AppointmentStatus statusEnum;
            if (!Enum.IsDefined(typeof(AppointmentStatus), req.Status))
                statusEnum = AppointmentStatus.Pending;
            else
                statusEnum = (AppointmentStatus)req.Status;

            var appt = new Appointment
            {
                AppointmentDateTime = req.AppointmentDateTime,
                Status = statusEnum,
                ClientID = req.ClientID,
                CarID = req.CarID,
                MechanicID = req.MechanicID
            };

            _context.Appointment.Add(appt);
            await _context.SaveChangesAsync();

            return Ok(new CreateAppointmentResponse { Id = appt.ID });
        }
    }

    
    public class AppointmentDto
    {
        public int ID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int Status { get; set; }

        public ClientDto? Client { get; set; }
        public CarDto? Car { get; set; }
        public MechanicDto? Mechanic { get; set; }
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
        public int Status { get; set; } = 0; 
        public int ClientID { get; set; }
        public int CarID { get; set; }
        public int? MechanicID { get; set; }
    }

    public class CreateAppointmentResponse
    {
        public int Id { get; set; }
    }
}
