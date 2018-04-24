using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManager.Model;
using Newtonsoft.Json;
using FlightManager.ThirdParty.ThirdPartyModel;
using System.IO;
using System.Globalization;
using FlightManager.Common.Constants;

namespace FlightManager.ThirdParty
{
    public class ThirdPartyService : IThirdPartyService
    {
        /// <summary>
        /// Return a list of all airports from the json file of airports
        /// https://gist.github.com/tdreyno/4278655
        /// </summary>
        /// <returns>IEnumerable of Airport</returns>
        public IEnumerable<Airport> GetAllAirports()
        {
            using (StreamReader r = new StreamReader(AppSetting.AirportsJsonFilePath))
            {
                string json = r.ReadToEnd();
                var airports = JsonConvert.DeserializeObject<List<JsonAirport>>(json).Where(x => !string.IsNullOrEmpty(x.Country)).OrderBy(x => x.City);

                return airports.Select(x => new Airport() {
                    Name = x.Name,
                    Code = x.Code,
                    Country = x.Country,
                    Latitude = Single.Parse(x.Lat, CultureInfo.InvariantCulture),
                    Longitude = Single.Parse(x.Lon, CultureInfo.InvariantCulture),
                    City = string.IsNullOrWhiteSpace(x.City) ? null : x.City
                });
            }
        }
    }
}
