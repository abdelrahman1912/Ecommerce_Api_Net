using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.DTos
{
    public class LoginDto
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
        public LoginDto(bool success = false, string msg = null!, string token = null!, string refreshToken = "")
        {
            this.success = success;
            this.message = msg;
            this.token = token;
            this.refreshToken = refreshToken;
        }
    }
}
