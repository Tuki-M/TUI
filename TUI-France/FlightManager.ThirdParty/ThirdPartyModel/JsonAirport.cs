using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ThirdParty.ThirdPartyModel
{
    public class JsonAirport
    {
        public string Code { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
    }
}