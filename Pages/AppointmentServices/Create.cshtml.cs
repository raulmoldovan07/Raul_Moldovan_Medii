using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.AppointmentServices
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
            ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "AppointmentDisplay");
            ViewData["ServiceTypeID"] = new SelectList(_context.ServiceType, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public AppointmentService AppointmentService { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // refacem dropdown-urile dacă apar erori
                ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "AppointmentDisplay");
                ViewData["ServiceTypeID"] = new SelectList(_context.ServiceType, "ID", "Name");
                return Page();
            }

            _context.AppointmentService.Add(AppointmentService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

