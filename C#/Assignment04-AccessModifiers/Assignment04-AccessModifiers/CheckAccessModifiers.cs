using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_AccessModifiers
{
    public class CheckAccessModifiers
    {
        public string PublicVariable = "public";
        private string PrivateVariable = "private";
        protected string ProtectedVariable = "protected";
        protected internal string ProtectedInternalVariable = "ProtectedInternal";
        private protected string PrivateProtectedVariable = "PrivateProtected";
        public string AccessPrivate()
        {
            return PrivateVariable;
        }

    }
}
