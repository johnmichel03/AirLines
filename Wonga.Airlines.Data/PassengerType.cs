using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Data
{
    public enum PassengerType
    {
        [Description("general")]
        General = 1,
        [Description("loyalty")]
        Loyalty = 2,
        [Description("airline")]
        Airline = 3,
        [Description("Discounted price")]
        Discounted = 4
    }
}
