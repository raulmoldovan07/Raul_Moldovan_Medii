using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.AppointmentServices
{
    public class EditModel : PageModel
    {
        private readonly Raul_Moldovan_Medii.Data.ServiceAutoContext _context;

        public EditModel(Raul_Moldovan_Medii.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppointmentService AppointmentService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentservice =  await _context.AppointmentService.FirstOrDefaultAsync(m => m.ID == id);
            if (appointmentservice == null)
            {
                return NotFound();
            }
            AppointmentService = appointmentservice;
           ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "ID");
           ViewData["ServiceTypeID"] = new SelectList(_context.ServiceType, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppointmentService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentServiceExists(AppointmentService.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppointmentServiceExists(int id)
        {
            return _context.AppointmentService.Any(e => e.ID == id);
        }
    }
}
