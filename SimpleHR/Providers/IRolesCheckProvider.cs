using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHR.Providers
{
    public interface IRolesCheckProvider
    {
        bool IsEmployeeInHR(string loginId);
    }
}
