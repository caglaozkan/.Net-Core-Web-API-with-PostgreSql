using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayerRepository;
using NLayerRepository.Repositoryies;

namespace NLayer.Repository.Repositoryies
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {

            // Eager loading yapmış oldum
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
