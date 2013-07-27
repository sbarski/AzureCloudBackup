using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AzureCloudBackup.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/core")
                .Include("~/Scripts/jquery-2.0.3.js")
                .Include("~/Scripts/knockout-2.3.0.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery.gridster.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr")
                .Include("~/Scripts/jquery.signalR-1.1.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/azure-backup-client")
                .Include("~/Scripts/Client/AzureBackupClient.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-responsive")
                .Include("~/Content/bootstrap-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/site")
                .Include("~/Content/site.css")
                .Include("~/Content/jquery.gridster.css"));
        }
    }
}