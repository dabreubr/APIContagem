using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace APIContagem
{
    public static class IdentityHelpers
    {
        public static string ShortName(this WindowsIdentity Identity)
        {
            if (null != Identity)
            {
                return Identity.Name.Split(new char[] { '\\' })[1];
            }
            return string.Empty;
        }
    }
}
