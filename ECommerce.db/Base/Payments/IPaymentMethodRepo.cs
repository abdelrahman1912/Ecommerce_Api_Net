using ECommerce.db.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.db.Base.Payments
{
    public interface IPaymentMethodRepo
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();
    }
}
