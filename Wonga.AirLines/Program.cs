using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Wonga.Airlines.Business;
using Wonga.Airlines.Common;
using Wonga.Airlines.Data;
using Wonga.Airlines.Services;


namespace Wonga.Airlines
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = BootStrapper.Initialise();
            var processFile = container.Resolve<IProcessFile>();
            var processInputOutData = new ProcessInputData(processFile);
            var routeInfo = processInputOutData.ReadInputData();
            if (routeInfo != null)
            {
                //Note: Passed as in memory collection to replicate the data entities
                container.RegisterInstance(typeof(IRoute), "dataContext", routeInfo);
                var processOutputData = new ProcessOutputData(routeInfo);
                processOutputData.WriteOutputFile();
            }


        }
    }
}
