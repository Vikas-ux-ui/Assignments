using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_AccessModifiers
{
    internal class SubClassForPRotected:CheckAccessModifiers
    {
        public string ToAccessProtected()
        {
            return ProtectedVariable;
        }
        public string ToAccessPrivateProtected()
        {
            return PrivateProtectedVariable;
        }

    }
}
