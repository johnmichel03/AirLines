using Wonga.Airlines.Data;

namespace Wonga.Airlines.Services
{
    public interface IFlightService
    {
        IFlightSummary CalculateFlightSummaryReport();
        bool CanFlightProceed();
    }
}
