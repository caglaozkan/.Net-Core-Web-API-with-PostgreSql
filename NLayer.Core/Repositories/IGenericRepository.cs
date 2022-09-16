using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();// productrepository.where(x => x.Id >5 ).orderby.tolistasync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);   // bu arkadaş t alıcak geriye bool deger dönecek t den kastım entityi alacak x.Id>5 içinde bool dönecek.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync (T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update (T entity);
       void Remove (T entity);
       void RemoveRange (IEnumerable<T> entities);

    }
}
