using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Wonga.Airlines.Business;
using Wonga.Airlines.Common;
using Wonga.Airlines.Data;
using Wonga.Airlines.Services;


namespace Wonga.Airlines
{
    public class BootStrapper
    {

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //log4net.Config.XmlConfigurator.Configure();
            //container.RegisterType<ILog>(new InjectionFactory(
            //    factory => LogManager.GetLogger("GeneralLogger")));
            container.RegisterType<IProcessFile, ProcessTextFile>();
            container.RegisterType<IFlightService, FlightService>();
            container.RegisterType<IRoute, Route>();
            container.RegisterType<IPassengerManager, PassengerManager>();
            return container;
        }
    }
}
