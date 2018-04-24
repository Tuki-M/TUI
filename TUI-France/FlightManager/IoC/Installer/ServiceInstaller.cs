using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FlightManager.Service;
using FlightManager.Service.IService;
using FlightManager.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManager.IoC
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IFlightService>()
                    .ImplementedBy<FlightService>())
                .Register(
                    Component
                        .For<IThirdPartyService>()
                        .ImplementedBy<ThirdPartyService>());
        }
    }
}