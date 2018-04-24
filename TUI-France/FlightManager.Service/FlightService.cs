using FlightManager.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManager.Model;
using FlightManager.Repository.IRepository;
using FlightManager.ThirdParty;
using System.Device.Location;
using FlightManager.Common.Exceptions;

namespace FlightManager.Service
{
    /// <summary>
    /// Service & Business Layer
    /// </summary>
    public class FlightService : IFlightService
    {
        private IFlightRepository _flightRepository;
        private IThirdPartyService _thirPartyService;

        public FlightService(IFlightRepository flightRepository, IThirdPartyService thirPartyService)
        {
            _flightRepository = flightRepository;
            _thirPartyService = thirPartyService;
        }

        /// <summary>
        /// Create a new flight
        /// </summary>
        /// <param name="newFlight">new flight instance</param>
        /// <returns>A new flight persisted to repository layer</returns>
        public Flight CreateFlight(Flight newFlight)
        {
            SetAirports(newFlight);
            CalculateDitanceAndFuel(newFlight);
            return _flightRepository.AddFlight(newFlight);
        }

        /// <summary>
        /// Retreive a Flight from repository
        /// </summary>
        /// <param name="id">Id of known flight</param>
        /// <returns></returns>
        public Flight GetFlight(long id)
        {
            return _flightRepository.GetFlight(id);
        }

        /// <summary>
        /// List all airports from a third party service
        /// </summary>
        /// <returns>IEnumerable of airports</returns>
        public IEnumerable<Airport> ListAllAirports()
        {
            return _thirPartyService.GetAllAirports();
        }

        /// <summary>
        /// List of all flights from repository layer
        /// </summary>
        /// <returns>IEnumerable of flight</returns>
        public IEnumerable<Flight> ListAllFlights()
        {
            return _flightRepository.GetAllFlights();
        }

        /// <summary>
        /// Update a flight
        /// </summary>
        /// <param name="updatedFlight">the instance of flight to update</param>
        public void UpdateFlight(Flight updatedFlight)
        {
            var flight = GetFlight(updatedFlight.Id);

            if (flight == null)
                throw new FlightManagerException(Error.FlightNotFound);

            SetAirports(updatedFlight);

            if(flight.DepartureAirport.Code != updatedFlight.DepartureAirport.Code)
                flight.DepartureAirport = updatedFlight.DepartureAirport;

            if (flight.DestinationAirport.Code != updatedFlight.DestinationAirport.Code)
                flight.DestinationAirport = updatedFlight.DestinationAirport;

            flight.DepartureDateUtc = updatedFlight.DepartureDateUtc;
            CalculateDitanceAndFuel(flight);
            
            _flightRepository.UpdateFlight(flight);
        }


        #region private Methods
        /// <summary>
        /// Calaculate distance between two coordinates and the necessary fuel amount to make the trip 
        /// Based on : 
        /// Boeing 747 burns approximately 5 gallons of fuel per mile : 12 liters per kilometer
        /// a commercial aircraft will use about 10% of its fuel at takeoff 
        /// </summary>
        /// <param name="newFlight">flight instance</param>
        private static void CalculateDitanceAndFuel(Flight flight)
        {
            //calculate distance :
            var depCoord = new GeoCoordinate(flight.DepartureAirport.Latitude, flight.DepartureAirport.Longitude);
            var destCoord = new GeoCoordinate(flight.DestinationAirport.Latitude, flight.DestinationAirport.Longitude);

            flight.Distance = depCoord.GetDistanceTo(destCoord); //In miter

            //calculate fuel :
            //Boeing 747 burns approximately 5 gallons of fuel per mile : 12 liters per kilometer
            //a commercial aircraft will use about 10% of its fuel at takeoff 

            var fuelAmount = 12 * (flight.Distance / 1000) + 0.1 * (12 * (flight.Distance / 1000));
            flight.FuelAmount = fuelAmount; //In liters
        }

        /// <summary>
        /// Set the instance of airport from the code and list of all airports
        /// </summary>
        /// <param name="flight"></param>
        private void SetAirports(Flight flight)
        {
            //TO TO : create a method to retreive one airport by code in the tgird party service...

            var allAirports = ListAllAirports();
            flight.DepartureAirport = allAirports.FirstOrDefault(x => x.Code == flight.DepartureAirport.Code);
            flight.DestinationAirport = allAirports.FirstOrDefault(x => x.Code == flight.DestinationAirport.Code);
        }
        #endregion
    }
}
