using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBackupService : IBaseService<Backup>
    {
        void Export(User user);
        void ImportById(string id, User user);
    }
}
