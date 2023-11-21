using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BackupService : BaseService<Backup>, IBackupService
    {
        private readonly IBackupRepository backupRepository;
        static string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        static readonly string xmlFileName = "data.xml";
        static readonly string xmlFilePath = Path.Combine(appFolderPath, xmlFileName);
        static readonly string backupFolderName = "Backup";
        static readonly string backupFolderPath = Path.Combine(appFolderPath, backupFolderName);

        public BackupService(IBackupRepository backupRepository) : base(backupRepository)
        {
            this.backupRepository = backupRepository;
        }

        public void Export()
        {
            Directory.CreateDirectory(backupFolderPath);

            DateTime currentDatetime = DateTime.Now;
            string timestamp = currentDatetime.ToString("yyyyMMddHHmmss");
            string backupFileName = $"backup_{timestamp}.xml";
            string backupFilePath = Path.Combine(backupFolderPath, backupFileName);

            File.Copy(xmlFilePath, backupFilePath);

            Backup backup = new Backup() { Id = Guid.NewGuid().ToString(), Name = backupFileName, Date = currentDatetime };
            backupRepository.Create(backup);
        }

        public void ImportById(string id)
        {
            Backup backup = GetById(id);

            if (backup == null)
            {
                throw new Exception("Backup no encontrado");
            }

            string backupFilePath = Path.Combine(backupFolderPath, backup.Name);
            File.Copy(backupFilePath, xmlFilePath, true);
        }
    }
}
