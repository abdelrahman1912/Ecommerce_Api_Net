using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.DTos.Identity
{
    public class BaseUser
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
