using Microsoft.EntityFrameworkCore;
using Dominio;


namespace Persistencia{
    public class AppContext:DbContext
    {
        //Atributos

        public DbSet<Migrante> Migrantes{get;set;}
        public DbSet<Servicios> Servicios{get;set;}
<<<<<<< HEAD
        public DbSet<Usuario> Usuarios{get;set;}
        //public DbSet<Medida> Medidas{get;set;}
=======
        
        public DbSet<EntidadColaboradora> Entidada{get;set;}
>>>>>>> 0a779d337a566d32bbb79a32026fe2de5340d210
             
        
        //Metodos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=HackatonGrupo36WebDevelopers");
            }
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=> new{x.EquipoId,x.TorneoId});
        }
*/

    }

}