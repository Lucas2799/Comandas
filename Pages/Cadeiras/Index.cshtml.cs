using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using c= Models.Cadeiras;

namespace Comandas.Pages.Cadeiras
{
    public class IndexModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public IndexModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        public IList<c.Cadeiras> Cadeiras { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cadeiras != null)
            {
                Cadeiras = await _context.Cadeiras.ToListAsync();
            }
        }
    }
}
