using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static Boolean Verify(String websiteURL)
        {
            String path = @"C:\Users\Ryan\Desktop\Graph Test\microsoft-teams-phishing-detector\google-safe_browsing-api-v4-master\GoogleSearch.jar";
            Process process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "java.exe";
            process.StartInfo.Arguments = "-jar " + '"' + path;
            process.Start();
            process.StandardInput.WriteLine(websiteURL);
            String googleOutput = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Boolean isGoodSite = Convert.ToBoolean(googleOutput);
            return isGoodSite; 
        }

        static void Main(string[] args)
        {
            Boolean linkCheck = Verify("google.com");
            Console.WriteLine(linkCheck); 

        }

        static void TestCode()
        {
            System.Diagnostics.Process clientProcess = new Process();
            var startInfo = new ProcessStartInfo("java", @"-jar C:\Users\Ryan\Desktop\Graph Test\microsoft-teams-phishing-detector\google-safe_browsing-api-v4-master\GoogleSearch.jar")
            {
                RedirectStandardInput = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var process = Process.Start(startInfo);
            //process.StandardInput.WriteLine("https://malware.testing.google.test/testing/malware/");
            // String googleOutput = process.StandardOutput.ReadToEnd();
            // Console.WriteLine(googleOutput);
            process.WaitForExit();

            //  Boolean isGoodSite = Convert.ToBoolean(googleOutput);
            //Console.WriteLine(isGoodSite); 
        }
    }
       


    
}
