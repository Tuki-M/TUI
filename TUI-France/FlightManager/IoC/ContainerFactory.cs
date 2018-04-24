using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManager.IoC
{
    public class ContainerFactory
    {
        private static IWindsorContainer container;
        private static readonly object SyncObject = new object();

        public static IWindsorContainer Current()
        {
            if (container == null)
            {
                lock (SyncObject)
                {
                    if (container == null)
                    {
                        container = new WindsorContainer();
                        container.Install(new ControllerInstaller());
                        container.Install(new ServiceInstaller());
                        container.Install(new RepositoryInstaller());
                    }
                }
            }
            return container;
        }
    }
}