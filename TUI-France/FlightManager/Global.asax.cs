using Castle.Windsor;
using FlightManager.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FlightManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Insall Windosr containers
            ControllerBuilder.Current.SetControllerFactory(typeof(WindsorControllerFactory));
            SetPartialViewLocation();
        }


       
        /// <summary>
        /// Add the path /Partials/ to the default list of views location
        /// </summary>
        private void SetPartialViewLocation()
        {
            RazorViewEngine razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            if (razorEngine != null)
            {
                var newPartialViewFormats = new[]{
                    "~/Views/{1}/Partials/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };
                razorEngine.PartialViewLocationFormats = razorEngine.PartialViewLocationFormats.Union(newPartialViewFormats).ToArray();
            }
        }
    }
}
