using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using m=Models.Mesas;

namespace Comandas.Pages.Mesas
{
    public class EditModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public EditModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public m.Mesas Mesas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }

            var mesas =  await _context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
            if (mesas == null)
            {
                return NotFound();
            }
            Mesas = mesas;
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

            _context.Attach(Mesas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesasExists(Mesas.Id))
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

        private bool MesasExists(int id)
        {
          return (_context.Mesas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
