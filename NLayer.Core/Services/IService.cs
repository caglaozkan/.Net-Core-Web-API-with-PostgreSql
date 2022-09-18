using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);   // bu arkadaş t alıcak geriye bool deger dönecek t den kastım entityi alacak x.Id>5 içinde bool dönecek.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity); // normalde repository içinde bunlar voiddir ef core da bunların dönüş tipi yoktur async methodu yoktur ama service te db ye bunları yansıtacagımız için var. 
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);


    }
}
