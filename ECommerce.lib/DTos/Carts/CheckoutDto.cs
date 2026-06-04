using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.DTos.Carts
{
    public class CheckoutDto
    {
        public required Guid paymentmethodID { get; set; }
          public required IEnumerable<CartsDto> Carts { get; set; }
    }
}
