using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.Mechanics
{
    public class CreateModel : PageModel
    {
        private readonly Raul_Moldovan_Medii.Data.ServiceAutoContext _context;

        public CreateModel(Raul_Moldovan_Medii.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mechanic Mechanic { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mechanic.Add(Mechanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
