using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException() : base("Usuario y/o password deben tener 6 o mas caracteres")
        {
        }
    }
}
