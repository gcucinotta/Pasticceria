using Microsoft.EntityFrameworkCore;

namespace Pasticceria.Data.Service
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }
        public virtual DbSet<Entity.Utente> Utenti { get; set; }
        public virtual DbSet<Entity.Dolce> Dolci { get; set; }
        public virtual DbSet<Entity.Ingrediente> Ingredienti { get; set; }
        public virtual DbSet<Entity.UnitaMisura> UnitaMisura { get; set; }
    }
}