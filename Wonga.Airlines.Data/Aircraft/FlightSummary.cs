using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Data
{
    public class FlightSummary : IFlightSummary
    {
        public int TotalPassengerCount { get; set; }
        public int GeneralPassengerCount { get; set; }
        public int AirlinePassengerCount { get; set; }
        public int LoyaltyPassengerCount { get; set; }
        public int TotalNumberOfBags { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }
        public int TotalCostOfFlight { get; set; }
        public int TotalUnadjustedTicketRevenue { get; set; }
        public int TotalAdjustedRevenue { get; set; }
        public bool CanFlightProceed { get; set; }
        public int DiscountedPassengerCount { get; set; }
    }
}
