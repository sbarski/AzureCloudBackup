using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using AzureCloudBackup.Core.DTO;

namespace AzureCloudBackup.Core.Service
{
    public interface IBackupService
    {
        void Backup(string connectionString, string databaseName, Subject<string> messages);
    }
}
