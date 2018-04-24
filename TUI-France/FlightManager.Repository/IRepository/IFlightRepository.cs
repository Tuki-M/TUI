using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Repository.IRepository
{
    public interface IFlightRepository
    {
        Flight AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        Flight GetFlight(long Id);
        IEnumerable<Flight> GetAllFlights();
    }
}
