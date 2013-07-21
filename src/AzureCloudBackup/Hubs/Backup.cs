using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Web;
using AzureCloudBackup.Core.Service;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AzureCloudBackup.Hubs
{
    [HubName("backup")]
    public class Backup : Hub
    {
        public readonly IBackupService _backupService;

        public Backup(IBackupService backupService)
        {
            _backupService = backupService;
        }

        public void Create(string connectionString, string databaseName)
        {
            var messages = new Subject<string>();

            messages.Subscribe(m => Clients.All.broadcastMessage(m));

            _backupService.Backup(connectionString, databaseName, messages);
        }
    }
}