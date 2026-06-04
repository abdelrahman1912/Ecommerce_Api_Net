using ECommerce.db.Base;
using ECommerce.db.Context;
using ECommerce.db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Repos
{
    public class CartsRepo(AppDbContext context) : ICart
    {
        public async Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory> checkouts)
        {
            context.ProductHistories.AddRange(checkouts);
            return await context.SaveChangesAsync();
        }
    }
}
