using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public CreateModel(ServiceAutoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "CarDisplay");
            ViewData["MechanicID"] = new SelectList(_context.Mechanic, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // refacem dropdown-urile dacă apare eroare
                ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
                ViewData["CarID"] = new SelectList(_context.Car, "ID", "CarDisplay");
                ViewData["MechanicID"] = new SelectList(_context.Mechanic, "ID", "FullName");
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}