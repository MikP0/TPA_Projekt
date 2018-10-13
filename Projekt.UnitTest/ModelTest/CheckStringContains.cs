using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.UnitTest.ModelTest
{
    public static class CheckStringContains
    {
        public static bool ContainsAny(this string inputString, params string[] arrayOfNeededString)
        {
            foreach (string neededString in arrayOfNeededString)
            {
                if (inputString.Contains(neededString))
                    return true;
            }

            return false;
        }
    }
}
