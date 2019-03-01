using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process clientProcess = new Process();
            var startInfo = new ProcessStartInfo("java", @"-jar C:\Users\Class2018\Documents\Microsoft-Teams-Phishing-Detector\google-safe_browsing-api-v4-master\GoogleSearch.jar")
      {
        RedirectStandardInput = true,
        RedirectStandardError  = true,
        RedirectStandardOutput = true,
        UseShellExecute        = false
      };
            var process = Process.Start(startInfo);
            process.StandardInput.WriteLine("https://malware.testing.google.test/testing/malware/");
            process.WaitForExit();
            String googleOutput = process.StandardOutput.ReadToEnd();
            Boolean isGoodSite = Convert.ToBoolean(googleOutput);
            Console.WriteLine(isGoodSite); 
        }
    }
}
