using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayerRepository.Configurations;
using System.Reflection;

namespace NLayerRepository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // veritabanı yolunu startup dosyasında verebilmek için dbcontextoptions ı kullanırız.
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) // model oluşurken çalışacak olan method
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // bu assembly ler yani projeler içindeki tüm conf dosylarını alır.
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); // bi tane kullanmak istersen.


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()

            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Weight = 200,
                ProductId = 1
            },
            new ProductFeature()

            {
                Id = 2,
                Color = "Sarı",
                Height = 80,
                Weight = 200,
                ProductId = 1
            });






            //modelBuilder.Entity<Category>().HasKey(x => x.Id); // normalde biz category içinde sadece Id vererek bunu pk yaptık ama custom bir isim vermek istersen burda bunun pk oldugunu açık açık yazmamız gerekiyor bunu da best pricatice olarak configurasyon dosylarında yani burda yapıyoruz model içinde [key] şeklinde yapmak tercih edilmemeli.
            //// bu yaklışama fluent api olarak adlandırılır. // bunlar burda yapılavilir fakat best pricatesi açısından ayrı bir class içinde yapıcaz her entitiy için.

            base.OnModelCreating(modelBuilder);
        }

    }
}
