using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AzureCloudBackup.Core.Service;
using AzureCloudBackup.Infrastructure;
using AzureCloudBackup.ViewModel;
using Microsoft.AspNet.SignalR;

namespace AzureCloudBackup.Controllers
{
    public class BackupController : SiteController
    {


        public ActionResult Index()
        {
            var viewModel = new BackupViewModel();

            return View(viewModel);
        }
    }
}
