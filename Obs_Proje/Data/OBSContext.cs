using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Obs_Proje.Models;

namespace Obs_Proje.Data
{
    public class OBSContext:DbContext
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

        public DbSet<Obs_Proje.Models.OgrenciViewModel> OgrenciViewModel { get; set; }
    }

    public class EntityBase
    {
        public int Id { get; set; }
    }

    public class Ogrenci:EntityBase
    {
        [Display(Name ="Adı")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }  

        [Display(Name = "Öğrenci Numarası")]
        public int OkulNo { get; set; } 

        

        public virtual List<Ders> Dersler { get; set; }
        public virtual Bolum Bolum { get; set; }
        public virtual Adres Adres { get; set; }
    }

    public class Ders : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public int BolumId { get; set; }
        
        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual List<Bolum> Bolumler { get; set; }
    }

    public class Bolum : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual List<Ders> Dersler { get; set; }

    }

    public class Adres : EntityBase
    {
        
        public string Satir1 { get; set; }
        public string Satir2 { get; set; }
        public int IlceId { get; set; }

        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual Ilce Ilce { get; set; }
    }

    public class Sehir : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual List<Ilce> Ilceler { get; set; }
    }

    public class Ilce : EntityBase
    {
        
        public int SehirId { get; set; }

        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual Sehir Sehir { get; set; }
        public virtual List<Adres> Adresler { get; set; }
    }
}
