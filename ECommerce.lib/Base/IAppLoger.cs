using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.lib.Base
{
    public interface IAppLoger<T> 
    {
        void LogInformation(string message);
        void LogInfo(string message);
        void LogError(Exception ex, string message);
    }
}
