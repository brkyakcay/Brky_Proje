using Microsoft.EntityFrameworkCore;
using Obs_Proje.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Obs_Proje.Data
{
    public class OBSContext : IdentityDbContext<WebUser, WebRole, int >
    {
        public OBSContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ogrenci>()
                .HasIndex(col => col.Id)
                .IsUnique();

            modelBuilder.Entity<Ilce>()
                .HasIndex(col => new { col.SehirId, col.Adi })
                .IsUnique();
        }


    }

    public class WebUser : IdentityUser<int>
    {
        public string Fullname { get; set; }
    }

    public class WebRole : IdentityRole<int>
    {
        public string Title { get; set; }
    }

}
