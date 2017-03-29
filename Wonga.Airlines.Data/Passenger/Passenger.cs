using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wonga.Airlines.Helper;

namespace Wonga.Airlines.Data
{
    public abstract class Passenger 
    {
        private Passenger() { }
        protected Passenger(string firstName, byte age, string passengerType)
        {
            FirstName = firstName;
            Age = age;
            PassengerType = passengerType;
        }
        public string FirstName { get; set; }
        public int Age { get; set; }

        private string _passengerType;
        public string PassengerType
        {
            get { return _passengerType; }
            set
            {
                PassengerType enumType;
                if (Enum.TryParse(value, true, out enumType))
                {
                    _passengerType = value;
                }
                else
                {
                    // the error message and it's code can be moved configuralble resource file or xml file
                    throw new ArgumentOutOfRangeException("Invalid_PassengerType", _passengerType, "Invalid passenger type");
                }
            }
        }

        private readonly int _baggageCount = 1;
        public virtual int BaggageCount
        {
            get { return _baggageCount; }
        }
    }
}
