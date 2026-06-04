using ECommerce.db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Base
{
    public interface ICart
    {
        Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory>checkouts);
    }
}
