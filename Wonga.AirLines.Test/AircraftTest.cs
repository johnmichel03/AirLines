using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Test
{
    [TestFixture]
    public class AircraftTest
    {
        [Test]
        public void Constuctor_Aircraft_ShouldSetProperties()
        {
            var aircraft = new Aircraft("Gulfstream-G550", 8);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Aircraft_InvalidSeat()
        {
            var aircraft = new Aircraft("Gulfstream-G550", 0);
        }

        [Test]
        public void Aircraft_CheckCanProceed()
        {
            
        }

        public void Total_adjusted_revenuefortheflight_exceeds_thetotalcostoftheflight()
        {
            
        }

    }
}
