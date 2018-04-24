using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ThirdParty
{
    public interface IThirdPartyService
    {
        IEnumerable<Airport> GetAllAirports();

    }
}
