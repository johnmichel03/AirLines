using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Data
{
    public class Aircraft
    {
        public Aircraft(string aircraftName, short noOfSeat)
        {
            AircraftName = aircraftName;
            NoOfSeat = noOfSeat;
        }
        public string AircraftName { get; set; }
        private short _noOfSeat;
        public short NoOfSeat
        {
            get { return _noOfSeat; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _noOfSeat = value;
                }

            }
        }
        //public IQueryable<Passenger> Passengers { get; set; }

        private IQueryable<Passenger> _passengers;
        public IQueryable<Passenger> Passengers
        {
            get { return _passengers; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Passenger_NullObjectReference", new ApplicationException("Passenger information should not be null."));
                }
                else
                {
                    _passengers = value;
                }
            }
        }
    }
}
