using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {
        private readonly Raul_Moldovan_Medii.Data.ServiceAutoContext _context;

        public IndexModel(Raul_Moldovan_Medii.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public IList<ServiceType> ServiceType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ServiceType = await _context.ServiceType.ToListAsync();
        }
    }
}
