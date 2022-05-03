using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanteDev.Utils
{
    public class ValidationHelper
    {
        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} must be required";
        }
        public static string GetLetterMessage(string propName)
        {
            return $"{propName} must consist of only letters";
        }
        public static string GetUniqueMessage(string propName)
        {
            return $"{propName} is already exist";
        }
        public static string GetRequiredLength(string propName, int length)
        {
            return $"{propName} should be {length} digits";
        }
    }
}
