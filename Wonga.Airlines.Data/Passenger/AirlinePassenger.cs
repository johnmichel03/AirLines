using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Data
{
    /// <summary>
    /// Employee of the Wonga Airlines
    /// </summary>
    public class AirlinePassenger : Passenger
    {
        public AirlinePassenger(string firstName, byte age, string passengerType)
            : base(firstName, age, passengerType)
        {

        }
    }
}
