using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class RVMException : ApplicationException
    {
        public RVMException() : base()    {
        }

        public RVMException(string message) : base(message)   {
        }

        public RVMException(string message, Exception innerExc) 
            : base(message, innerExc)   {
        }
    }
}
