using ECommerce.db.Base.Payments;
using ECommerce.db.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Repos
{
    public class PaymentMethodRepo(AppDbContext _context) : IPaymentMethodRepo
    {
        public async Task<IEnumerable<Entities.Payments.PaymentMethod>> GetAllPaymentMethods()
        {
            return await _context.PaymentMethods.AsNoTracking().ToListAsync();
        }
    }
}
