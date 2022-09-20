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
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options) 
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); 


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

    }
}
