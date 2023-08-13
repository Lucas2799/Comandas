using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using r=Models.Reservas;

namespace Comandas.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public DeleteModel(Comandas.Data.ComandasContext context)
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

            var reservas = await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);

            if (reservas == null)
            {
                return NotFound();
            }
            else 
            {
                Reservas = reservas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }
            var reservas = await _context.Reservas.FindAsync(id);

            if (reservas != null)
            {
                Reservas = reservas;
                _context.Reservas.Remove(Reservas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
