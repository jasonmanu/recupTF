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
        static string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        static readonly string xmlFileName = "data.xml";
        static readonly string xmlFilePath = Path.Combine(appFolderPath, xmlFileName);
        static readonly string backupFolderName = "Backup";
        static readonly string backupFolderPath = Path.Combine(appFolderPath, backupFolderName);

        public BackupService(IBackupRepository backupRepository) : base(backupRepository)
        {
        }

        public void Export(User user)
        {
            Directory.CreateDirectory(backupFolderPath);

            DateTime currentDatetime = DateTime.Now;
            string timestamp = currentDatetime.ToString("yyyyMMddHHmmss");
            string backupFileName = $"backup_{timestamp}.xml";
            string backupFilePath = Path.Combine(backupFolderPath, backupFileName);

            Backup backup = new Backup() { Action = "Export", Timestamp = timestamp, UserId = user.Id, Username = user.Username, Date = currentDatetime, File = backupFileName };
            base.Create(backup);

            File.Copy(xmlFilePath, backupFilePath);
        }

        public void ImportById(string id, User user)
        {
            Backup backup = GetById(id);

            if (backup == null)
            {
                throw new Exception("Backup no encontrado");
            }

            string backupFilePath = Path.Combine(backupFolderPath, backup.File);
            File.Copy(backupFilePath, xmlFilePath, true);

            DateTime currentDatetime = DateTime.Now;
            string timestamp = currentDatetime.ToString("yyyyMMddHHmmss");

            Backup backupRegistry = new Backup() {Action = "Import", Timestamp = timestamp, UserId = user.Id, Username = user.Username, Date = currentDatetime, File = backup.File };
            base.Create(backupRegistry);
        }
    }
}
