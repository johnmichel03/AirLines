using System;
using Wonga.Airlines.Data;
using System.Collections.Generic;
using NUnit.Framework;
using Wonga.Airlines.Helper;

namespace Wonga.Airlines.Test
{
    [TestFixture]
    public class PassengerTest
    {

        [Test]
        public void Constuctor_GeneralPassenger_ShouldSetProperties()
        {
            var passenger = new GeneralPassenger("john", 33, "airline");
            Assert.AreEqual("john", passenger.FirstName);
            Assert.AreEqual(33, passenger.Age);
            PassengerType ptype;
            Assert.AreEqual(true, Enum.TryParse<PassengerType>("airline", true, out ptype));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InValid_PassengerType_ArgumentOutOfRangeException()
        {
            var passenger = new GeneralPassenger("john", 33, "normal");
        }


        [Test]
        public void Constuctor_For_LoyaltyPassenger_ShouldSetProperties()
        {
            var passenger = new LoyaltyPassenger("john", 33, "loyalty", 105, true, true);
            Assert.AreNotEqual("John", passenger.FirstName);
            Assert.AreEqual(33, passenger.Age);

            Assert.AreEqual(true, EnumHelper<PassengerType>.IsValidEnum("loyalty"));
        }

    }
}
