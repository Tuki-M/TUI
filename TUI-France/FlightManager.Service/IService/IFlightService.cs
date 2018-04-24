using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Service.IService
{
    public interface IFlightService
    {
        Flight CreateFlight(Flight newFlight);
        void UpdateFlight(Flight flight);
        IEnumerable<Flight> ListAllFlights();
        Flight GetFlight(long id);
        IEnumerable<Airport> ListAllAirports();
    }
}
