using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace FlightManager.Data.Mapping
{
    public class AirportMap : ClassMap<Airport>
    {
        public AirportMap()
        {
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Country);
            Map(x => x.City);
            Map(x => x.Longitude);
            Map(x => x.Latitude);
            Map(x => x.Name);
        }
    }
}
