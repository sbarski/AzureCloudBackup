using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using AzureCloudBackup.Core.DTO;
using AzureCloudBackup.Core.Model;

namespace AzureCloudBackup.Core.Service
{
    public interface IBackupService
    {
        void Backup(string exportName, string connectionString, string databaseName, string blobStorageAccount, string blobStorageKey, ExportType exportType, Subject<string> messages);
    }
}
