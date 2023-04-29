using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Drawing.Printing;
using System.Drawing;
using System;
using System.Security.Cryptography;

namespace BookStore.WebApp.Data
{
    public partial class BookStoreContext : DbContext
    {
        public DbSet<Lang> Langs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Translator> Translators { get; set; }

        public BookStoreContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Ignore(x => x.FullName);
            modelBuilder.Entity<Translator>().Ignore(x => x.FullName);

            modelBuilder.Entity<Book>().Property(x => x.CreatedDate)
                //.HasDefaultValue(DateTime.Now)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Publisher>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Address>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Author>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Translator>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Campaign>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            SeedLangs(modelBuilder);
            SeedAuthor(modelBuilder);
            SeedPublisher(modelBuilder);
            SeedCities(modelBuilder);
            SeedCategories(modelBuilder);

            //TODO: Hata !
            //modelBuilder.Entity<Book>().HasData(
            //    new City { Id = 1, Name= "Çile"},
            //    new City { Id = 2, Name = "Sevdalı Bulut"},
            //    new City { Id = 3, Name = "Kar" },
            //    new City { Id = 4, Name = "Kuyucaklı Yusuf" },
            //    new City { Id = 5, Name = "Sinekli Bakkal" },
            //    new City { Id = 6, Name = "Huzur" },
            //    new City { Id = 7, Name = "Aylak Adam"},
            //    new City { Id = 8, Name = "Tutunamayanlar"}
            //    );
        }

    
    }

}
