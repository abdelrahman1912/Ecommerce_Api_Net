using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.DTos.Carts
{
    public class CartsDto
    {
        public required Guid ProductId {  get; set; }
        public required int Quantity { get; set; }
    }
}
