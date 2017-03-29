using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Data;
using Wonga.Airlines.Helper;

namespace Wonga.Airlines.Business
{

    /// <summary>
    /// Handle airline business service
    /// </summary>
    public class PassengerManager : IPassengerManager
    {
        private readonly IRoute _dataContext;
        public PassengerManager(IRoute dataContext)
        {
            _dataContext = dataContext;
        }

        public int GetTotalNumberOfPassenger()
        {
            return _dataContext.Aircraft.Passengers.Select(sel => sel.FirstName).Count();
        }

        public int GetPassengerCountByPassengerType(string passengerType)
        {
            int count = _dataContext
                .Aircraft
                .Passengers
                .Where(pngr => pngr.PassengerType.Equals(passengerType))
                .Select(sel => sel.FirstName)
                .ToList()
                .Count();
            return count;
        }

        private IQueryable<LoyaltyPassenger> GetAllLoyaltyPassengers()
        {
            var loyaltyPassenger = _dataContext.Aircraft
                .Passengers
                .Where(pngr => pngr.PassengerType.Equals("loyalty"))
                .Cast<LoyaltyPassenger>()
                .AsQueryable();
            return loyaltyPassenger;
        }

        public int GetTotalNumberOfBags()
        {
            var normalBagsCount = _dataContext.Aircraft.Passengers.Count();
            var extraBagsCount = 0;

            var loyaltyPassengers = GetAllLoyaltyPassengers().ToList();
            loyaltyPassengers.ForEach(lp =>
            {
                extraBagsCount += lp.HasExtraBaggage ? 1 : 0;
            });

            var totalDiscountedPassengerCount = GetPassengerCountByPassengerType("Discounted");
            return (normalBagsCount + extraBagsCount) - totalDiscountedPassengerCount;
        }

        public int GetTotalLoyaltyPointsRedeemed()
        {
            var totalRedeemedPoints = 0;
            var loyaltyPassengers = GetAllLoyaltyPassengers().Where(lp => lp.CanRedeemLoyaltyPoints).ToList();
            loyaltyPassengers.ForEach(lp =>
            {
                totalRedeemedPoints += lp.CurrentLoyaltyPoints;
            });
            return totalRedeemedPoints;
        }

        public int GetTotalCostOfFlight()
        {
            return _dataContext.CostPerPassenger * GetTotalNumberOfPassenger();
        }

        public int GetTotalUnadjustedTicketRevenue()
        {
            return _dataContext.TicketPrice * GetTotalNumberOfPassenger();
        }

        public int GetTotalAdjustedRevenue()
        {
            var totalAdjustedRevenue = GetTotalUnadjustedTicketRevenue() -
                                       (GetTotalLoyaltyPointsRedeemed() +
                                        (_dataContext.TicketPrice * GetPassengerCountByPassengerType("airline") + GetTotalTicketPriceForDiscountedPassenger()));
            return totalAdjustedRevenue;
        }

        public bool CanFlightProceed()
        {
            var canGo = GetTotalAdjustedRevenue() > GetTotalCostOfFlight()      //The total adjusted revenue for the flight exceeds the total cost of the flight.
                && GetTotalNumberOfPassenger() <= _dataContext.Aircraft.NoOfSeat  //The number of passengers does not exceed the number of seats on the plane
                && GetBookingPercentage() > _dataContext.MinimumTakeOffLoadPercentage  //The percentage of booked seats exceeds the minimum set for the route.
                ;

            return canGo;
        }

        public byte GetBookingPercentage()
        {
            //var takeOffLoadPercentage = (byte)((_dataContext.Aircraft.NoOfSeat / GetTotalNumberOfPassenger()) * 100);
            var takeOffLoadPercentage = (byte)((GetTotalNumberOfPassenger() / _dataContext.Aircraft.NoOfSeat) * 100);
            return takeOffLoadPercentage;

        }
        /// <summary>
        /// To get consolidated summary report of a flight
        /// </summary>
        /// <returns></returns>
        public IFlightSummary GetFlightSummaryReport()
        {
            var flightReport = new FlightSummary()
            {
                AirlinePassengerCount = GetPassengerCountByPassengerType("airline"), //TODO : modify it to read from Passenger Enum Type
                CanFlightProceed = CanFlightProceed(),
                GeneralPassengerCount = GetPassengerCountByPassengerType("general"),
                LoyaltyPassengerCount = GetPassengerCountByPassengerType("loyalty"),
                TotalAdjustedRevenue = GetTotalAdjustedRevenue(),
                TotalCostOfFlight = GetTotalCostOfFlight(),
                TotalLoyaltyPointsRedeemed = GetTotalLoyaltyPointsRedeemed(),
                TotalNumberOfBags = GetTotalNumberOfBags(),
                TotalPassengerCount = GetTotalNumberOfPassenger(),
                TotalUnadjustedTicketRevenue = GetTotalUnadjustedTicketRevenue(),
                DiscountedPassengerCount = GetPassengerCountByPassengerType("discounted")
            };
            ;
            return flightReport;
        }

        public int GetTotalTicketPriceForDiscountedPassenger()
        {
            var discountedPrice = 0;
            discountedPrice = (_dataContext.TicketPrice / 2) * GetPassengerCountByPassengerType("Discounted");
            return discountedPrice;
        }


    }
}
