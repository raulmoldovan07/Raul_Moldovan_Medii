using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly Raul_Moldovan_Medii.Data.ServiceAutoContext _context;

        public DeleteModel(Raul_Moldovan_Medii.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FirstOrDefaultAsync(m => m.ID == id);

            if (car is not null)
            {
                Car = car;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                Car = car;
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
