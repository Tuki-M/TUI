using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManager.Models
{
    public class FlightModel
    {
        public long Id { get; set; }
        public IEnumerable<SelectListItem> Airports { get; set; }
        [Required]
        public string DestinationAirportCode { get; set; }
        public string DestinationAirportName { get; set; }
        [Required]
        public string DepartureAirportCode { get; set; }
        public string DepartureAirportName { get; set; }
        [Required]
        public DateTime DepartureDateUtc { get; set; }
        public double Distance { get; set; }
        public double FuelAmount { get; set; }

        public FlightModel() { DepartureDateUtc = DateTime.UtcNow; }
        public FlightModel(Flight flight)
        {
            this.Id = flight.Id;
            this.DestinationAirportCode = flight.DestinationAirport.Code;
            this.DepartureAirportCode = flight.DepartureAirport.Code;
            this.DepartureDateUtc = flight.DepartureDateUtc;
            this.Distance = flight.Distance;
            this.FuelAmount = flight.FuelAmount;
            this.DestinationAirportName = $"{flight.DestinationAirport.Country} ({flight.DestinationAirport.Name ?? flight.DestinationAirport.City})";
            this.DepartureAirportName = $"{flight.DepartureAirport.Country} ({flight.DepartureAirport.Name ?? flight.DepartureAirport.City})";
        }

        public Flight GetFlight()
        {
            return new Flight() {
                Id = this.Id,
                FuelAmount = this.FuelAmount,
                Distance = this.Distance,
                DepartureDateUtc = this.DepartureDateUtc,
                DepartureAirport = new Airport() { Code = this.DepartureAirportCode},
                DestinationAirport = new Airport() { Code = this.DestinationAirportCode }
            };
        }
    }
}