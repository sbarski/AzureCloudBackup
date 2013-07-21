using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace AzureCloudBackup.App_Start
{
    public class HubConfig
    {
        public static void Register(RouteCollection routeCollection)
        {
            var configuration = new HubConfiguration() {EnableDetailedErrors = true};

            routeCollection.MapHubs(configuration);
        }
    }
}