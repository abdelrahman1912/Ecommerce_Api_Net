using ECommerce.lib.DTos.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.Base
{
    public interface IPaymentMethodSrvc
    {
        Task<IEnumerable<PaymentsMethodDto>> GetPaymentMethod();
    }
}
