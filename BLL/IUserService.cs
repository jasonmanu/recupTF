using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IUserService : IBaseService<User>
    {
        User Login(string username, string password);
        void Register(User user);
    }
}
