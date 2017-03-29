using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines
{
   public static class DisplayMessage
    {
        public static void ShowErrorMessage(Exception ex)
        {
            Console.WriteLine("\n FAILURE : \n Inner Exception :" + (ex.InnerException != null ? ex.InnerException.ToString() : ""));
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Detailed Exceptiopn:");
            Console.WriteLine(ex.ToString());
            Console.WriteLine("\nPlease press any key to end the application.");
            Console.ReadLine();
        }
    }
}
