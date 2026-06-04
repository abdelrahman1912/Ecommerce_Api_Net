using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.lib.Exaptions
{
    public class NotFoundEx(string msg): Exception(msg)
    {
    }
}
