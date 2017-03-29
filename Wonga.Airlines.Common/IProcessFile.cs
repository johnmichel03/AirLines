using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.Airlines.Data;

namespace Wonga.Airlines.Common
{
    public interface IProcessFile : IDisposable
    {
        IRoute ProcessInputFile(string filePath);
        //void ProcessOutputFille(string filePath);
    }
}
