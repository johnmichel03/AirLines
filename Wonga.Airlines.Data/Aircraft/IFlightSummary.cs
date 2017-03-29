namespace Wonga.Airlines.Data
{
    public interface IFlightSummary
    {
        int TotalPassengerCount { get; set; }
        int GeneralPassengerCount { get; set; }
        int AirlinePassengerCount { get; set; }
        int LoyaltyPassengerCount { get; set; }
        int TotalNumberOfBags { get; set; }
        int TotalLoyaltyPointsRedeemed { get; set; }
        int TotalCostOfFlight { get; set; }
        int TotalUnadjustedTicketRevenue { get; set; }
        int TotalAdjustedRevenue { get; set; }
        bool CanFlightProceed { get; set; }
        int DiscountedPassengerCount { get; set; }
    }
}