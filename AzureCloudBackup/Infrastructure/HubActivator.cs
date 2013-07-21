using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using SimpleInjector;

namespace AzureCloudBackup.Infrastructure
{
    public class MyHubActivator : IHubActivator
    {
        private readonly Container _container;

        public MyHubActivator(Container container)
        {
            _container = container;
        }

        public IHub Create(HubDescriptor descriptor)
        {
            return _container.GetInstance(descriptor.HubType) as IHub;
        }
    }
}