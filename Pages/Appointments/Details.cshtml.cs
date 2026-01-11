using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly Raul_Moldovan_Medii.Data.ServiceAutoContext _context;

        public DetailsModel(Raul_Moldovan_Medii.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.ID == id);

            if (appointment is not null)
            {
                Appointment = appointment;

                return Page();
            }

            return NotFound();
        }
    }
}
