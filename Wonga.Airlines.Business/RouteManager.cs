using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Business
{
    public class RouteManager
    {

        private readonly IRoute _dataContext;

        public RouteManager(IRoute dataContext)
        {
            _dataContext = dataContext;
        }
        
    }



}
