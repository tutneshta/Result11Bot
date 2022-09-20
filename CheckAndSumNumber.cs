using System;
using System.Collections.Generic;
using System.Text;

namespace Result11Bot
{
    internal static class CheckAndSumNumber
    {
        public static bool CheckNumber(string s)
        {
            s = s.Replace(" ", string.Empty);

            var isParseToInt = int.TryParse(s, out _);

            return isParseToInt;
        }

        public static int SumNumber(string s)
        {
            var arr = s.Split();
            var sum = 0;
            foreach (var variable in arr)
            {
                sum += int.Parse(variable);
            }

            return sum;
        }
    }
}