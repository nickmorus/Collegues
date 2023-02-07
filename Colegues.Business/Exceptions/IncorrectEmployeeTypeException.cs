using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegues.Business.Exceptions
{
    internal class IncorrectEmployeeTypeException : ArgumentException
    {
        public IncorrectEmployeeTypeException() : base("Incorrect employee type"){}
    }
}
