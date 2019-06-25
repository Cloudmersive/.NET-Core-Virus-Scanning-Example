using Cloudmersive.APIClient.NETCore.VirusScan.Api;
using Cloudmersive.APIClient.NETCore.VirusScan.Client;
using Cloudmersive.APIClient.NETCore.VirusScan.Model;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace VirusScanningExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            var files = Directory.EnumerateFiles("C:\\temp");

            foreach (var file in files)
            {
                // Configure API key authorization: Apikey
                Configuration.Default.AddApiKey("Apikey", "e4c8ad3b-335b-4082-a297-f3153da07770");



                var apiInstance = new ScanApi();
                using (var inputFile = new System.IO.FileStream(file, System.IO.FileMode.Open))
                {
                    try
                    {
                        // Scan a file for viruses
                        VirusScanResult result = apiInstance.ScanFile(inputFile);
                        Debug.WriteLine(JsonConvert.SerializeObject(result));
                    }
                    catch (Exception e)
                    {
                        Debug.Print("Exception when calling ScanApi.ScanFile: " + e.Message);
                    }
                }
            }
        }
    }
}
