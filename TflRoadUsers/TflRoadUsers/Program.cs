using System;

namespace TflRoadUsers
{
    public struct Road
    {
        public string displayName;
        public string statusSeverity;
        public string statusSeverityDescription;
    }

    class Program
    {                  
        static void Main(string[] args)
        {
            Console.WriteLine("Enter road name");
            string roadName = Console.ReadLine();
            TflRoadUsers tflRoadUsers = new TflRoadUsers(new System.Net.Http.HttpClient());
            tflRoadUsers.RunAsync(roadName).GetAwaiter().GetResult();
        }
      
    }
     
    }
