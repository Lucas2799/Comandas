using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Cadeiras;
using Models.Mesas;
using Models.Reservas;

namespace Comandas.Data
{
    public class ComandasContext : DbContext
    {
        public ComandasContext (DbContextOptions<ComandasContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Cadeiras.Cadeiras> Cadeiras { get; set; } = default!;

        public DbSet<Models.Mesas.Mesas> Mesas { get; set; } = default!;

        public DbSet<Models.Reservas.Reservas> Reservas { get; set; } = default!;
    }
}
