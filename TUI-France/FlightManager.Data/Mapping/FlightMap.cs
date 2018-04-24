using FlightManager.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Mapping
{
    public class FlightMap : ClassMap<Flight>
    {
        public FlightMap()
        {
            Id(x => x.Id);
            Map(x => x.Distance);
            Map(x => x.FuelAmount);
            Map(x => x.DepartureDateUtc);

            References(x => x.DepartureAirport).Cascade.All();
            References(x => x.DestinationAirport).Cascade.All();
        }
    }
}
