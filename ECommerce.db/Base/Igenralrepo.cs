using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.db.Base
{
    public interface Igenralrepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
    }
}
