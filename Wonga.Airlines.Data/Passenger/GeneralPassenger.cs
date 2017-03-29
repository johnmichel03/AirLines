using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Data
{
    public class GeneralPassenger : Passenger
    {
        public GeneralPassenger(string firstName, byte age, string passengerType)
            : base(firstName, age, passengerType)
        {

        }
    }
}
