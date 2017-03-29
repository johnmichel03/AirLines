using Wonga.Airlines.Data;

namespace Wonga.Airlines.Business
{
    public interface IPassengerManager
    {
        int GetTotalNumberOfPassenger();
        int GetPassengerCountByPassengerType(string passengerType);
        int GetTotalNumberOfBags();
        int GetTotalLoyaltyPointsRedeemed();
        int GetTotalCostOfFlight();
        int GetTotalUnadjustedTicketRevenue();
        int GetTotalAdjustedRevenue();
        bool CanFlightProceed();
        byte GetBookingPercentage();
        IFlightSummary GetFlightSummaryReport();
    }
}