using Microsoft.EntityFrameworkCore;
using WebApiPrueba1.Entidades;

//using WebApiPrueba1.Entidades;
//using Microsoft.EntityFrameworkCore;

namespace WebApiPrueba1
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Huevo> Huevos { get; set; }

        public DbSet<Encargado> Encargados { get; set; }
    }
}
