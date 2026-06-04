using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.lib.DTos
{
    public class ResponseDto
    {
        public bool success { get; set; }
        public string message { get; set; }
        public ResponseDto(bool success= false, string msg = null!)
        {
            this.success = success;
            this.message = msg;
        }
    }
}
