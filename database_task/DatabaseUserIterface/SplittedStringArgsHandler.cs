using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseUserIterface
{
    public static class SplittedStringArgsHandler
    {
        public static string GetArgValueFromRawString(string[] splittedString, int argIndex, string defaultValue)
        {
            for (var i = 0; i < splittedString.Length; i++)
            {
                if (i == argIndex)
                {
                    return splittedString[i];
                }
            }

            return defaultValue;
        }
    }
}
