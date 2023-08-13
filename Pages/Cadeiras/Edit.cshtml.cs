using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using c =Models.Cadeiras;

namespace Comandas.Pages.Cadeiras
{
    public class EditModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public EditModel(Comandas.Data.ComandasContext context)
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

            var cadeiras =  await _context.Cadeiras.FirstOrDefaultAsync(m => m.Id == id);
            if (cadeiras == null)
            {
                return NotFound();
            }
            Cadeiras = cadeiras;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cadeiras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadeirasExists(Cadeiras.Id))
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

        private bool CadeirasExists(int id)
        {
          return (_context.Cadeiras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
