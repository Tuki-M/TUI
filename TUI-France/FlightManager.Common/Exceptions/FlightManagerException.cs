using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Common.Exceptions
{
    public class FlightManagerException : Exception
    {
        private Error _error;
        private string _message;

        public Error Error {
            get { return _error; }
            private set { }
        }

        public override string Message {
            get { return _message; }
        }

        public FlightManagerException()
        {
            _error = Error.UnknownError;
            _message = ExceptionDescription.ResourceManager.GetString(_error.ToString()); ;
        }

        /// <summary>
        /// Create new instance of the FlightManagerException with the specified error enum and params format
        /// </summary>
        /// <param name="error">error enum</param>
        /// <param name="param">extra parameters format</param>
        public FlightManagerException(Error error,string[] param = null) : base()
        {
            _error = error;
            if(param != null)
                _message = string.Format(ExceptionDescription.ResourceManager.GetString(error.ToString()), param);
             else
                _message = ExceptionDescription.ResourceManager.GetString(error.ToString());
                        
        }


        public FlightManagerException(string message) : base(message)
        {
            _error = Error.UnknownError;
            _message = message;
        }

        public FlightManagerException(string message, Exception innerException) : base(message, innerException)
        {
            _error = Error.UnknownError;
            _message = message;
        }

        protected FlightManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return _message;
        }
    }
}
