using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Data
{
    public class LoyaltyPassenger : Passenger
    {
        public LoyaltyPassenger(string firstName, byte age, string passengerType, int currentLoyaltyPoints, bool canRedeemLoyaltyPoints, bool hasExtraBaggage)
            : base(firstName, age, passengerType)
        {
            this.CurrentLoyaltyPoints = currentLoyaltyPoints;
            this.CanRedeemLoyaltyPoints = canRedeemLoyaltyPoints;
            this.HasExtraBaggage = hasExtraBaggage;
        }

        public int CurrentLoyaltyPoints { get; private set; }
        public bool CanRedeemLoyaltyPoints { get; private set; }
        public bool HasExtraBaggage { get; private set; }
        private const int _baggageCount = 2;

        public override int BaggageCount
        {
            get {
                return this.HasExtraBaggage ? _baggageCount : base.BaggageCount;
            }
        }
    }
}
