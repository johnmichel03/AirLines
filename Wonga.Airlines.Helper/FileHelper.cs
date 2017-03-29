using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Helper
{
    public class FileHelper
    {
        public static bool IsValidFile(string filePath, string extension)
        {
            var fileExtension = Path.GetExtension(filePath);
            return File.Exists(filePath) && (fileExtension != null && fileExtension.ToLower().Equals(extension));
        }


        public static string GetInputFile()
        {
            //var filePath = @"H:\SampleProjects\Wonga.AirLines\Wonga.AirLines\InputFile\InputFile_FlightInformation.txt";
            var rootPath = Path.GetFullPath("../../");
            return Path.Combine(rootPath, "InputFile/InputFile_FlightInputInformation.txt");
        }

        public static string GetOutputFile()
        {
            var rootPath = Path.GetFullPath("../../");
            return Path.Combine(rootPath, "OutputFile/OutputFile_FlightSummaryInformation.txt");
        }
    }
}
