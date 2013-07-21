using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AzureCloudBackup.Core.Service;
using AzureCloudBackup.Infrastructure;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace AzureCloudBackup.App_Start
{
    public class ContainerConfig
    {
        public static void Register()
        {
            var container = new Container();

            container.Register<IBackupService, BackupService>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.RegisterMvcAttributeFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new MyHubActivator(container));
        }
    }
}