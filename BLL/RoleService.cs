using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRoleService : IBaseService<Role>
    {
    }

    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IRoleRepository roleRepository): base(roleRepository)
        {
        }
    }

}
