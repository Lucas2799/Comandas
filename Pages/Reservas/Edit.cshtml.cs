using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using r=Models.Reservas;

namespace Comandas.Pages.Reservas
{
    public class EditModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public EditModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public r.Reservas Reservas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reservas =  await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);
            if (reservas == null)
            {
                return NotFound();
            }
            Reservas = reservas;
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

            _context.Attach(Reservas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservasExists(Reservas.Id))
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

        private bool ReservasExists(int id)
        {
          return (_context.Reservas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
