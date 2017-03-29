using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Business
{
    public class AircraftManager
    {
        private readonly IRoute _dataContext;

        public AircraftManager(IRoute dataContext)
        {
            _dataContext = dataContext;
        }

 
        
    }
}
