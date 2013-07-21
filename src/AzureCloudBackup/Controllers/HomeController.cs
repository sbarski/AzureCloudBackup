using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureCloudBackup.Infrastructure;

namespace AzureCloudBackup.Controllers
{
    public class HomeController : SiteController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
