using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonga.Airlines.Data
{
    public interface IDataContext
    {
        IQueryable<Passenger> GetAllPassenger();
        void AddNewPassenger(Passenger passenger);
    }
}
