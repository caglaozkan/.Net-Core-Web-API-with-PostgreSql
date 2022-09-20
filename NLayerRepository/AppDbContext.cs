using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayerRepository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options) // veritabanı yolunu startup dosyasında verebilmek için dbcontextoptions ı kullanırız.
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

            base.OnModelCreating(modelBuilder); 
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                        {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                        }
                        case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                                entityReferance.UpdatedDate = DateTime.Now;
                                break;
                            }
                            
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                                entityReferance.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
