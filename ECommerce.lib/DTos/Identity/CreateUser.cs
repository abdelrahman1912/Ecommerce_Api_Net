using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.DTos.Identity
{
    public class CreateUser:BaseUser
    {
        public required string FullName { get; set; }
        public required string confirmPassword { get; set; }
    
    }
}
