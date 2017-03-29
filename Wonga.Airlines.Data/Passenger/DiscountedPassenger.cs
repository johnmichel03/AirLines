using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Wonga.Airlines.Data
{
    public class DiscountedPassenger : Passenger
    {
        public DiscountedPassenger(string firstName, byte age, string passengerType)
            : base(firstName, age, passengerType)
        {
        }

        private readonly int _baggageCount = 0;
        public override int BaggageCount
        {
            get { return _baggageCount; }
        }

    }
}

