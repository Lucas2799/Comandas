using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Comandas.Data;
using m=Models.Mesas;

namespace Comandas.Pages.Mesas
{
    public class CreateModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public CreateModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public m.Mesas Mesas { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Mesas == null || Mesas == null)
            {
                return Page();
            }

            _context.Mesas.Add(Mesas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
