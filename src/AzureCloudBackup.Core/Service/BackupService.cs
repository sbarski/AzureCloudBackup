using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using AzureCloudBackup.Core.DTO;
using AzureCloudBackup.Core.Model;
using Microsoft.SqlServer.Dac;

namespace AzureCloudBackup.Core.Service
{
    public class BackupService : IBackupService
    {
        private Subject<string> _messages = null;

        public void Backup(string exportName, string connectionString, string databaseName, string blobStorageAccount, string blobStorageKey, ExportType exportType, Subject<string> messages)
        {
            try
            {
                _messages = messages;

                var dacServices = new DacServices(connectionString);

                dacServices.Message += dacServices_Message;
                dacServices.ProgressChanged += dacServices_ProgressChanged;

                switch (exportType)
                {
                    case ExportType.Bacpac:
                    {
                        dacServices.ExportBacpac(@"c:\temp\file.bacpac", databaseName);
                        break;
                    }

                    case ExportType.Dacpac:
                    {
                        var dacExtractOptions = new DacExtractOptions
                        {
                            ExtractApplicationScopedObjectsOnly = true,
                            ExtractReferencedServerScopedElements = false,
                            VerifyExtraction = true,
                            Storage = DacSchemaModelStorageType.Memory
                        };

                        dacServices.Extract(@"c:\temp\file.dacpac", databaseName, "DACPAC", new Version(1, 0, 0), "Dacpac Extract", null, dacExtractOptions);
                        break;
                    }
                }
            }
            catch (DacServicesException e)
            {
                _messages.OnNext(string.Format("Error occurred: {0}. Inner Exception: {1}", e.Messages, e.InnerException));
            }
            catch (ArgumentException e)
            {
                _messages.OnNext(string.Format("Could not parse parameters: {0}. Inner Exception: {1}", e.Message, e.InnerException));
            }
        }

        private void dacServices_ProgressChanged(object sender, DacProgressEventArgs e)
        {
            _messages.OnNext(string.Format("Progress Event:{0} Progrss Status:{1}", e.Message, e.Status));
        }

        private void dacServices_Message(object sender, DacMessageEventArgs e)
        {
            _messages.OnNext(string.Format("Message Type:{0} Prefix:{1} Number:{2} Message:{3}", e.Message.MessageType, e.Message.Prefix, e.Message.Number, e.Message.Message));
        }
    }
}
