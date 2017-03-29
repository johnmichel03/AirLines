

using System.Collections;
using System.Collections.Generic;
using System.IO;
using Wonga.Airlines.Business;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Services
{
    public class FlightService : IFlightService
    {
        private readonly IRoute _route;
        private readonly IPassengerManager _passengerManager;

        public FlightService(IRoute dataContext)
        {
            _route = dataContext;
            _passengerManager = new PassengerManager(dataContext);
        }

        public virtual IFlightSummary CalculateFlightSummaryReport()
        {
            return _passengerManager.GetFlightSummaryReport();
        }

        public virtual bool CanFlightProceed()
        {
            return _passengerManager.CanFlightProceed();
        }

    }
}
