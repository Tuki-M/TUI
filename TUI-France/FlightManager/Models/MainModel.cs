using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManager.Models
{
    public class MainModel
    {
        public FlightModel NewFlight { get; set; }
        public IEnumerable<FlightModel> StoredFlights { get; set; }

        public MainModel()
        {
            NewFlight = new FlightModel();
            StoredFlights = new List<FlightModel>();
        }
    }
}