using FlightManager.Common.Exceptions;
using FlightManager.Data;
using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManager.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DataSourceSession.Instance.OpenSession();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DataSourceSession.Instance.CloseSession();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            DataSourceSession.Instance.CloseSession();

            base.OnException(filterContext);
        }

        internal void ValidateModel(FlightModel model)
        {
            if (model == null)
                throw new FlightManagerException(Error.ModelValidationEmpty);
            else if (model.DepartureDateUtc < DateTime.UtcNow)
                throw new FlightManagerException(Error.DepartureDateUtcValidationError);
            if (string.IsNullOrWhiteSpace(model.DepartureAirportCode) || string.IsNullOrWhiteSpace(model.DestinationAirportCode))
                throw new FlightManagerException(Error.DepartureOrDestinationAirportError);
        }
    }
}