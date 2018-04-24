using FlightManager.Common.Exceptions;
using FlightManager.Handlers;
using FlightManager.Model;
using FlightManager.Models;
using FlightManager.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FlightManager.Controllers
{
    [ErrorHandler]
    public class FlightsController : BaseController
    {
        private IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public ActionResult Index()
        {
            var model = new MainModel();

            var allAirports = _flightService.ListAllAirports();
            var allFlights = _flightService.ListAllFlights();

            model.NewFlight.Airports = allAirports.Select(x => new SelectListItem() { Text = $"{x.City ?? x.Country} ({x.Name})", Value = x.Code });
            model.StoredFlights = allFlights.Select(x => new FlightModel(x));

            return View(model);
        }


        [HttpPost]
        public PartialViewResult Create(FlightModel model)
        {
            ValidateModel(model);

            var flight = _flightService.CreateFlight(model.GetFlight());
            var newModel = new FlightModel(flight); 

            return PartialView("_DetailFlight", newModel);
        }

        public PartialViewResult Edit(int id)
        {
            var flight = _flightService.GetFlight(id);

            if (flight == null)
                throw new FlightManagerException(Error.FlightNotFound);

            var allAirports = _flightService.ListAllAirports();

            var model = new FlightModel(flight);
            model.Airports = allAirports.Select(x => new SelectListItem() { Text = $"{x.Country} ({x.Name ?? x.City})", Value = x.Code });


            return PartialView("_EditFlight", model);
        }

        [HttpPost]
        public void Edit(FlightModel model)
        {
            ValidateModel(model);
            _flightService.UpdateFlight(model.GetFlight());
        }
        
    }
}
