using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Common.Exceptions
{
    /// <summary>
    /// Enumeration of the handled errors of the app
    /// </summary>
    public enum Error
    {
        UnknownError = 0,
        ConnectionStringEmpty = 1,
        ModelValidationEmpty = 2,
        DepartureDateUtcValidationError = 3,
        DepartureOrDestinationAirportError = 4,
        FlightNotFound = 5,
    }
}
