using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.SharedLayer.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        /*Örnek olarak bir siparişi almak istiyorum bunun için ilk expressionımı yazdım, buna ek olarak bu sipariş kim tarafından verildi onu da tutmak istiyorum
         2. expression da bunun için var, ekstra tutabilceğim bilgiler için bunu array olarak tanımlarım ve birden fazla parametre alabilme ihtimali için 
        params eklerim*/
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);   //Get with filter
        //Predicate null gelirse tüm hepsi gelir
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
