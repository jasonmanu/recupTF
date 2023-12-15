using DAL;
using System.Collections.Generic;

namespace BLL
{
    public interface IRoleService : IBaseService<Role>
    {
        List<string> GetAllPermissions(Role role);
    }

    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
        }

        public List<string> GetAllPermissions(Role role)
        {
            List<string> allPermissions = new List<string>(role.Permissions);

            if (role is CompositeRole compositeRole)
            {
                foreach (var subRole in compositeRole.SubRoles)
                {
                    allPermissions.AddRange(GetAllPermissions(subRole));
                }
            }
            else
            {
                allPermissions.Add(role.Name);
            }

            return allPermissions;
        }
    }
}
