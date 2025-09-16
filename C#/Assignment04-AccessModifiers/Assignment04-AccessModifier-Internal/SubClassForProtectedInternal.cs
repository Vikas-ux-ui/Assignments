using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment04_AccessModifiers;

namespace Assignment04_AccessModifier_Internal
{
    internal class SubClassForProtectedInternal:CheckAccessModifiers
    {
        
        public string AccessProtectedInternal()
        {
            return ProtectedInternalVariable;
        }
    }
}
