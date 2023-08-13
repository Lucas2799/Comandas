using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comandas.Data;
using m=Models.Mesas;

namespace Comandas.Pages.Mesas
{
    public class IndexModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public IndexModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        public IList<m.Mesas> Mesas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mesas != null)
            {
                Mesas = await _context.Mesas.ToListAsync();
            }
        }
    }
}
