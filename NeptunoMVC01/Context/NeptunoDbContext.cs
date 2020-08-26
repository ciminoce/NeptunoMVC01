using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NeptunoMVC01.Models;

namespace NeptunoMVC01.Context
{
    public class NeptunoDbContext:DbContext
    {
        public NeptunoDbContext():base("MiConexion")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<NeptunoDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Pais> Paises { get; set; }
    }
}