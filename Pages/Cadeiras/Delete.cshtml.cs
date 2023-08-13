using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using c =Models.Cadeiras;

namespace Comandas.Pages.Cadeiras
{
    public class DeleteModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public DeleteModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        [BindProperty]
      public c.Cadeiras Cadeiras { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cadeiras == null)
            {
                return NotFound();
            }

            var cadeiras = await _context.Cadeiras.FirstOrDefaultAsync(m => m.Id == id);

            if (cadeiras == null)
            {
                return NotFound();
            }
            else 
            {
                Cadeiras = cadeiras;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cadeiras == null)
            {
                return NotFound();
            }
            var cadeiras = await _context.Cadeiras.FindAsync(id);

            if (cadeiras != null)
            {
                Cadeiras = cadeiras;
                _context.Cadeiras.Remove(Cadeiras);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
