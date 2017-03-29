using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.Airlines.Helper
{
    public class EnumHelper<T> where T : struct
    {

        public static bool IsValidEnum(string enumCode)
        {
            T enumType;
            var enumValue = Enum.TryParse<T>(enumCode, true, out enumType);
            return enumValue;
        }

        public static T GetEnumDescription(string enumCode)
        {
            T outValue;
            Enum.TryParse<T>(enumCode.ToLower(), true, out outValue);
            return outValue;
        }
    }


}
