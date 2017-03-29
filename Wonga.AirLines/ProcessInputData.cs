using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Common;
using Wonga.Airlines.Data;
using Wonga.Airlines.Helper;
using Wonga.Airlines.Services;

namespace Wonga.Airlines
{
    public class ProcessInputData
    {
        private readonly IProcessFile _processFile;

        internal ProcessInputData(IProcessFile processFile)
        {
            _processFile = processFile;
        }

        //private string GetInputFile()
        //{
        //    //var filePath = @"H:\SampleProjects\Wonga.AirLines\Wonga.AirLines\InputFile\InputFile_FlightInformation.txt";
        //    var rootPath = Path.GetFullPath("../../");
        //    return Path.Combine(rootPath, "InputFile/InputFile_FlightInputInformation.txt");
        //}

        //private string GetOutputFile()
        //{
        //    var rootPath = Path.GetFullPath("../../");
        //    return Path.Combine(rootPath, "OutputFile/OutputFile_FlightSummaryInformation.txt");
        //}
        public IRoute ReadInputData()
        {
            IRoute flightInformation = null;
            try
            {
                Console.WriteLine("\n Input file being processed.Please wait for a while.......\n");
                //var directory = System.IO.Path.GetDirectoryName("InputFile");
                string filePath = FileHelper.GetInputFile();
                flightInformation = _processFile.ProcessInputFile(filePath);

                Console.WriteLine("\n Input file has been processed successfully..!");
            }
            catch (ApplicationException appEx)
            {
                DisplayMessage.ShowErrorMessage(appEx);
            }
            catch (Exception ex)
            {
                DisplayMessage.ShowErrorMessage(ex);
            }
            return flightInformation;
        }

        

    }
}
