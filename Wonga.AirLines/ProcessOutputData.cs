using System;
using System.IO;
using System.Text;
using Wonga.Airlines.Business;
using Wonga.Airlines.Common;
using Wonga.Airlines.Data;
using Wonga.Airlines.Helper;
using Wonga.Airlines.Services;

namespace Wonga.Airlines
{
    public class ProcessOutputData
    {
        private readonly IRoute _route;
        private readonly IFlightService _flightService;
        private readonly IRoute _dataContext;
        private StringBuilder _outputText;

        public ProcessOutputData(IRoute dataContext)
        {
            _dataContext = dataContext;
            _flightService = new FlightService(_dataContext);
        }

        public void WriteOutputFile()
        {
            var flightSummary = _flightService.CalculateFlightSummaryReport();
            _outputText = new StringBuilder();

            try
            {
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalPassengerCount));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.GeneralPassengerCount));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.AirlinePassengerCount));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.LoyaltyPassengerCount));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalNumberOfBags));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalLoyaltyPointsRedeemed));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalCostOfFlight));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalUnadjustedTicketRevenue));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.TotalAdjustedRevenue));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.CanFlightProceed ? "TRUE" : "FALSE"));
                _outputText.AppendFormat(string.Format("{0} ", flightSummary.DiscountedPassengerCount));

                File.WriteAllText(FileHelper.GetOutputFile(), _outputText.ToString());
            }
            catch (Exception ex)
            {
                DisplayMessage.ShowErrorMessage(ex);
            }
            finally
            {
                _outputText = null;
            }

            Console.WriteLine("\n Output result has been written sucessfully..!\n");
            Console.WriteLine("\n Press any key to exit the flight console application.");
            Console.ReadLine();
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (this._outputText != null)
        //            _outputText = null;
        //    }
        //    // free native resources here if there are any
        //}
    }
}