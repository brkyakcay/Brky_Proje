using Microsoft.EntityFrameworkCore;
using Obs_Proje.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Obs_Proje.Data
{
    //    public class OBSContext : IdentityDbContext<WebUser, WebRole, int>
    public class OBSContext : DbContext
    {
        public OBSContext(DbContextOptions options) : base(options) { }

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

            modelBuilder.Entity<Ders>().HasData(
                new Ders { Id = 1, OgretmenId = 1, BolumId = 1, Adi = "Front-End Development" },
                new Ders { Id = 2, OgretmenId = 1, BolumId = 1, Adi = "Asp.Net Web Development" },
                new Ders { Id = 3, OgretmenId = 1, BolumId = 1, Adi = "Database Management" }
                );

            modelBuilder.Entity<Bolum>().HasData(
                new Bolum { Id = 1, Adi = "Bilgisayar Mühendisliği" }
                );

            modelBuilder.Entity<Ogrenci>().HasData(
                new Ogrenci { Id = 1, Adi = "Berkay", Soyadi = "Akçay", BolumId = 1, OkulNo = 210219056 }
                );

            modelBuilder.Entity<Ogretmen>().HasData(
                new Ogretmen { Id = 1, Adi = "Can", Soyadi = "Demirel", BolumId = 1, SicilNo = 001 }
                );
        }
    }

    //public class WebUser : IdentityUser<int>
    //{
    //    public string Fullname { get; set; }
    //}

    //public class WebRole : IdentityRole<int>
    //{
    //    public string Title { get; set; }
    //}

}
