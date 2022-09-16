using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository.Repositoryies
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class  // where T :class burda tnin bir class oldugunu belirtmemiz gerekiyor.
    {

        protected readonly AppDbContext _context; // protected miras aldıgın yerde erişebilirsin.
        private readonly DbSet<T> _dbSet;   // db set enttity yani veritabanındaki tabloya karşılık gelir. // readonly yapınca bu arkadaşlara ya burda deger atarsın yada contracter da bunlar dışında deger atama da hata alır.set edilmemesi gerek

        

        public GenericRepository(AppDbContext context) // bu şekilde contracter da geçtik.
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
