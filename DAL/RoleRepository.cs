using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
    }

    public class RoleRepository : XmlRepository<Role>, IRoleRepository
    {
    }

}
