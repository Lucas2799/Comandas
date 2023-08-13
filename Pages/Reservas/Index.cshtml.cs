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
    public class IndexModel : PageModel
    {
        private readonly Comandas.Data.ComandasContext _context;

        public IndexModel(Comandas.Data.ComandasContext context)
        {
            _context = context;
        }

        public IList<r.Reservas> Reservas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservas != null)
            {
                Reservas = await _context.Reservas.ToListAsync();
            }
        }
    }
}
