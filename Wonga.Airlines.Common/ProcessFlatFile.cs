using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Data;
using Wonga.Airlines.Helper;

namespace Wonga.Airlines.Common
{
    public class ProcessTextFile : IProcessFile
    {
        /*  ASSUMPTION: Input file entry should be entered  as per the same input file inputfile folder in the console application  
         */

        /// <summary>
        /// Load input file and process the data
        /// </summary>
        /// <param name="filePath">input flat file path</param>
        /// <returns>IRoute type object</returns>

        private string[] _inputDataLines;
        private const string FileExtension = ".txt";
        IRoute route = null;

        public IRoute ProcessInputFile(string filePath)
        {
            using (this)
            {
                if (FileHelper.IsValidFile(filePath, FileExtension) == false)
                    throw new ApplicationException("Invalid input file or format.The format should be (" + FileExtension + ")");

                _inputDataLines = File.ReadAllLines(filePath);
                ValidateInputData(_inputDataLines);

                var dataCollection = _inputDataLines.GetEnumerator();
                dataCollection.MoveNext();
                route = GetRouteInfo(dataCollection.Current.ToString());
                dataCollection.MoveNext();
                route.Aircraft = GetAircraftInfo(dataCollection.Current.ToString());
                var passengers = new List<Passenger>();
                dataCollection.MoveNext();
                do
                {
                    passengers.Add(GetPassengerInfo(dataCollection.Current.ToString()));
                } while (dataCollection.MoveNext());

                route.Aircraft.Passengers = passengers.AsQueryable();
            }

            return route;
        }


        #region Private methods
        private void ValidateInputData(string[] inputData)
        {
            var route = inputData.FirstOrDefault();
            var isRouteExistAtFirst = route != null && route.Split(' ').ToList().Contains("route");
            if (isRouteExistAtFirst == false)
                throw new ApplicationException("Route information should be available at the first entry in the file");
            var totalRouteCount = inputData.Where(idata => idata.ToLower().Contains("route")).Select(sel => sel.Length).Count();

            if (totalRouteCount > 1)
            {
                throw new ApplicationException("Route information should be added only once in the input file.");
            }
            if (totalRouteCount <= 0)
            {
                throw new ApplicationException("Route information is missing.");
            }

            var totalAircraftCount = inputData.Where(idata => idata.ToLower().Contains("aircraft")).Select(sel => sel.Length).Count();
            if (totalAircraftCount > 1)
            {
                throw new ApplicationException("Aircraft information should be added only once in the input file.");
            }

            if (totalAircraftCount <= 0)
            {
                throw new ApplicationException("Aircraft information is missing.");
            }
        }
        /* ASSUMPTION : Route entries are provided in the input file as per the required format and information */
        private IRoute GetRouteInfo(string routeData)
        {
            var data = routeData.ToString().Split(' ').ToList();
            return new Route(data[2], data[3], Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToByte(data[6]));
        }

        /* ASSUMPTION : Route entries are provided in the input file as per the required format and information */
        private Aircraft GetAircraftInfo(string aircraftData)
        {
            var data = aircraftData.ToString().Split(' ').ToList();
            return new Aircraft(data[2], Convert.ToInt16(data[3]));
        }

        /*ASSUMPTION :  passenger entries are provided in the input file as per the required format and information */
        private Passenger GetPassengerInfo(string aircraftData)
        {
            var data = aircraftData.Split(' ').ToList();
            var passengerType = EnumHelper<PassengerType>.GetEnumDescription(data[1]);

            switch (passengerType)
            {
                case PassengerType.General:
                    return new GeneralPassenger(data[2], Convert.ToByte(data[3]), data[1]);
                case PassengerType.Airline:
                    return new AirlinePassenger(data[2], Convert.ToByte(data[3]), data[1]);
                case PassengerType.Loyalty:
                    return new LoyaltyPassenger(data[2], Convert.ToByte(data[3]), data[1], Convert.ToInt32(data[4]), Convert.ToBoolean(data[5].ToLower()), Convert.ToBoolean(data[6].ToLower()));
                case PassengerType.Discounted:
                    return new DiscountedPassenger(data[2], Convert.ToByte(data[3]), data[1]);
                default:
                    throw new ApplicationException("Invalid passenger type ( " + data[1] + ")");
            }
        }

        public void Dispose()
        {
            if (this._inputDataLines != null)
            {
                _inputDataLines = null;
            }

        }

        #endregion

    }
}
