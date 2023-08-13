using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using m= Models.Mesas;

namespace Comandas.Pages.Mesas
{
    public class DetailsModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public DetailsModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

      public m.Mesas Mesas { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }

            var mesas = await _context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
            if (mesas == null)
            {
                return NotFound();
            }
            else 
            {
                Mesas = mesas;
            }
            return Page();
        }
    }
}
