using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Model
{
    public class Flight
    {
        public virtual long Id {get;set;}
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public virtual DateTime DepartureDateUtc { get; set; }
        public virtual double Distance { get; set; }
        public virtual double FuelAmount { get; set; }
    }
}
