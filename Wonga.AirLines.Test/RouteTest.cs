using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using Rhino.Mocks;
using Wonga.Airlines.Business;
using Wonga.Airlines.Data;
using Wonga.Airlines.Services;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Test
{
    [TestFixture]
    public class RouteTest
    {
        [TestFixtureSetUp]
        public void SetUpdata()
        {

        }

        [Test]
        public void Constructor_Route_Should_SetProperties()
        {
            var routeSource = new Route()
            {
                Orgin = "London",
                Destination = "Dublin",
                Aircraft = null,
                CostPerPassenger = 100
            };
            var route = new Route("London", "Dublin", 100, 150, 75);
            Assert.AreEqual(route,route);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Route_Invalid_MinimumTakeOffLoadPercentage()
        {
            var route = new Route("London", "Dublin", 100, 150, 0);
        }

    }
}
