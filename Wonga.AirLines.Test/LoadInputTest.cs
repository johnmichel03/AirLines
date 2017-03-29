using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wonga.Airlines.Data;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Test
{
    [TestFixture]
    public class LoadInputTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_Rout_Aircraft_Passengers_ThrowExceptionForMissingInputData()
        {
            //var mockflightService = MockRepository.GenerateMock<IFlightService>();
            // var flightService = new FlightService(mockflightService,);

            var route = new Route("London", "Dublin", 100, 150, 75);
            var aircraft = new Aircraft("Gulfstream-G550", 8);
            IList<Passenger> passengers = new List<Passenger>();
            passengers.Add(new AirlinePassenger("Trevor", 54, "airline"));
            passengers.Add(new GeneralPassenger("Mark", 35, "general"));
            passengers.Add(new LoyaltyPassenger("Joan", 56, "loyalty", 100, false, true));
            passengers.Add(new DiscountedPassenger("Joan", 56, "discounted"));
            route.Aircraft = aircraft;
            aircraft.Passengers = passengers.AsQueryable();// passengers.AsQueryable();
        }

        public void Load_Rout_Aircraft_Discounted_Passengers()
        {
            //var mockflightService = MockRepository.GenerateMock<IFlightService>();
            // var flightService = new FlightService(mockflightService,);

            var route = new Route("London", "Dublin", 100, 150, 75);
            var aircraft = new Aircraft("Gulfstream-G550", 8);
            IList<Passenger> passengers = new List<Passenger>();
            passengers.Add(new AirlinePassenger("Trevor", 54, "airline"));
            passengers.Add(new GeneralPassenger("Mark", 35, "general"));
            passengers.Add(new LoyaltyPassenger("Joan", 56, "loyalty", 100, false, true));
            passengers.Add(new DiscountedPassenger("Joan", 56, "discounted"));
            route.Aircraft = aircraft;
            aircraft.Passengers = passengers.AsQueryable();// passengers.AsQueryable();
        }
    }
}
