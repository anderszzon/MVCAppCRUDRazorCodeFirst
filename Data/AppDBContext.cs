using Microsoft.EntityFrameworkCore;
using MVCAppCRUDRazorCodeFirst.Models;

namespace MVCAppCRUDRazorCodeFirst.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Atletlas> Atletlas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Atletlas>(tb =>
            {
                tb.HasKey(col => col.IdAtleta);   // KEY PRIMARY

                tb.Property(col => col.IdAtleta)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();  //AUTOINCREMENT

                tb.Property(col => col.AtletaName).HasMaxLength(50);
                tb.Property(col => col.AtletaType).HasMaxLength(50);

            });

            modelBuilder.Entity<Atletlas>().ToTable("Atletlas");  // NOMBRE DE LA TABLA PERSONALIZADA
        }

    }
}
