using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class NullLoginException : Exception
    {
        public NullLoginException() : base("Ususario y/o contraseña invalida")
        {
        }
    }
}
