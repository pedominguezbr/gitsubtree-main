using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambioAPI.Models
{
    public class MonedaDbContext:DbContext
    {
        public MonedaDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Moneda> Monedas{ get; set; }

    }
}
