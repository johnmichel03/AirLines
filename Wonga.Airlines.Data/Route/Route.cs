using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Data
{
    public class Route : IRoute
    {
        public Route(string orgin, string destination, int costPerPassenger, int ticketPrice, byte minimumTakeOffLoadPercentage)
        {
            Orgin = orgin;
            Destination = destination;
            CostPerPassenger = costPerPassenger;
            TicketPrice = ticketPrice;
            MinimumTakeOffLoadPercentage = minimumTakeOffLoadPercentage;
        }
        public Route(Route route)
        {
            Orgin = route.Orgin;
            Destination = route.Destination;
            CostPerPassenger = route.CostPerPassenger;
            TicketPrice = route.TicketPrice;
            MinimumTakeOffLoadPercentage = route.MinimumTakeOffLoadPercentage;
            Aircraft = route.Aircraft;

        }

        public Route()
        {
        }

        public string Orgin { get; set; }
        public string Destination { get; set; }
        public int CostPerPassenger { get; set; }
        public int TicketPrice { get; set; }

        private byte _minimumTakeOffLoadPercentage;
        public byte MinimumTakeOffLoadPercentage
        {
            get { return _minimumTakeOffLoadPercentage; }
            set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid_Min_TakeOff_Load", _minimumTakeOffLoadPercentage, "Invalid minimum take off load percentage..!");
                }
                else
                {
                    _minimumTakeOffLoadPercentage = value;
                }
            }
        }

        private Aircraft _aircraft;
        public Aircraft Aircraft
        {
            get { return _aircraft; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Aircraft_NullObjectReference", new ApplicationException("Aircaft information should not be null."));
                }
                _aircraft = value;
            }
        }

    }
}
