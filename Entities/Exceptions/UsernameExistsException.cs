using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UsernameExistsException : Exception
    {
        public UsernameExistsException() : base("Username ya esta usado")
        {
        }
    }
}
