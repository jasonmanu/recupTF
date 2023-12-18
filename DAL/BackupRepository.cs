using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackupRepository : XmlRepository<Backup>, IBackupRepository
    {
        public BackupRepository() : base("backup.xml")
        {
        }
    }
}
