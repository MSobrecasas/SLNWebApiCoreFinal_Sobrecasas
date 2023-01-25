using Microsoft.EntityFrameworkCore;
using SWProvincias_Sobrecasas.Models;

namespace SWProvincias_Sobrecasas.Data
{
    public class DBPaisFinalContext: DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
