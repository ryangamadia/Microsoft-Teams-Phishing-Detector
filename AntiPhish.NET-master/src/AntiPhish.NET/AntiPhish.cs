using System;
using System.Collections.Generic;
using System.Text;

namespace AntiPhishNET
{
    public static class AntiPhish
    {
        private static PhishingChecker _checker = new PhishingChecker();

        public static bool IsNotPhishingSite(string url)
        {
            var json = _checker.GetResult(
                    _checker.CheckUrlAsync(url).Result.Split(':')[1].Trim(new char[] { '\"', '}' }));

            return json;
        }

      //  static void Main(string[] args)
        //{
          ///  Console.WriteLine(IsNotPhishingSite("www.google.com"));
      //  }
    }
}
