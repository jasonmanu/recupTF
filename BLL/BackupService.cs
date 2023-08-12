using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BackupService : BaseService<Backup>, IBackupService
    {
        private readonly IBackupRepository backupRepository;

        public BackupService(IBackupRepository backupRepository) : base(backupRepository)
        {
            this.backupRepository = backupRepository;
        }

        public void Export()
        {
            string currentDateString = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");

            backupRepository.ExportBackup(currentDateString);

            Backup backup = new Backup() { Id= Guid.NewGuid().ToString(), Name = currentDateString, Date = DateTime.Now };
            backupRepository.Create(backup);
        }

        public void ImportById(string id)
        {
            if (id == null)
            {
                throw new Exception("Backup no encontrado");
            }

            Backup backup = GetById(id);

            if (backup == null)
            {
                throw new Exception("Backup no encontrado");
            }

            backupRepository.ImportBackup(backup.Name);
        }
    }
}
