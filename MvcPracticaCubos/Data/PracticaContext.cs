using Microsoft.EntityFrameworkCore;
using MvcPracticaCubos.Models;

namespace MvcPracticaCubos.Data
{
    public class PracticaContext : DbContext
    {

        public PracticaContext(DbContextOptions<PracticaContext> options) : base(options)
        { }

        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
