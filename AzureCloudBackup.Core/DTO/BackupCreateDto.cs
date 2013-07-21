using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCloudBackup.Core.DTO
{
    public class BackupCreateDto
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
