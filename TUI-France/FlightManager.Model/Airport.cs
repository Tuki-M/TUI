using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Model
{
    public class Airport
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Country { get; set; }
        public virtual float Latitude { get; set; }
        public virtual float Longitude { get; set; }
        public virtual string City { get; set; }
    }
}
