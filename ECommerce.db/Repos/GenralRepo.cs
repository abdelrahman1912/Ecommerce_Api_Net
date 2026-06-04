using ECommerce.db.Base;
using ECommerce.db.Context;
using ECommerce.lib.Exaptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.db.Repos
{
    public class GenralRepo<T>(AppDbContext appdb) : Igenralrepo<T> where T : class
    {
        public async Task<int> AddAsync(T entity)
        {
            appdb.Set<T>().Add(entity);
            return await appdb.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await appdb.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundEx($"{id} not found");
            }
            appdb.Set<T>().Remove(entity);
            return await appdb.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await appdb.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await appdb.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundEx($"{id} not found");
            }
            return entity!;

        }

        public async Task<int> UpdateAsync(T entity)
        {
            appdb.Set<T>().Update(entity);
            return await appdb.SaveChangesAsync();
        }
    }
}
