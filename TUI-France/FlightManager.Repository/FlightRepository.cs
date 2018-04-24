using FlightManager.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManager.Model;
using FlightManager.Data;

namespace FlightManager.Repository
{
    /// <summary>
    /// Repository layer
    /// </summary>
    public class FlightRepository : IFlightRepository
    {
        private static DataSourceSession _source;

        public FlightRepository()
        {
            _source = DataSourceSession.Instance;
        }

        /// <summary>
        /// Persiste a new flight in database
        /// </summary>
        /// <param name="flight">new flight instance</param>
        /// <returns></returns>
        public Flight AddFlight(Flight flight)
        {
            return _source.SaveOrUpdate(flight);
        }

        /// <summary>
        /// List all flight persisted in database
        /// </summary>
        /// <returns>IEnumerable of flights</returns>
        public IEnumerable<Flight> GetAllFlights()
        {
            return _source.GetAll<Flight>();
        }

        /// <summary>
        /// Retreive a persisted flight from database
        /// </summary>
        /// <param name="Id">Id of the known flight</param>
        /// <returns>instance of flight</returns>
        public Flight GetFlight(long Id)
        {
            return _source.Get<Flight>(Id);
        }

        /// <summary>
        /// Update an existing flight in database
        /// </summary>
        /// <param name="flight">the instance of the updated flight</param>
        public void UpdateFlight(Flight flight)
        {
            _source.Update(flight);
        }
    }
}
