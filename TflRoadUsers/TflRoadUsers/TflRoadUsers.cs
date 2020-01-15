using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web;
using System.Configuration;
namespace TflRoadUsers
{
    public class TflRoadUsers
    {
        private readonly HttpClient client;

        public TflRoadUsers(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        /// <summary>
        /// Fetches the status for the specified road id.
        /// </summary>
        /// <param name="roadName">The road id.</param>
        /// <returns></returns>
        public async Task RunAsync(string roadName)
        {
            Uri uri = new Uri("https://api.tfl.gov.uk/Road");
            // Update port # in the following line.
            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Get the road status
                var roads = await GetRoadStatusAsync(uri.ToFullUrl(roadName));

                if (roads.Any())
                {
                    var road = roads.FirstOrDefault();
                    Console.WriteLine($"Name: {road.displayName}\tRoad Status: " +
                    $"{road.statusSeverity}\tRoad Status Description: {road.statusSeverityDescription}");
                }
                else
                {
                    Console.WriteLine("Invalid road name specified. Press any key to exit application");
                    var key = Console.ReadKey();

                    Environment.Exit(-1);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public async Task<List<Road>> GetRoadStatusAsync(string path)
        {
            List<Road> road = new List<Road>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                road = await response.Content.ReadAsAsync<List<Road>>();
            }
            return road;
        }
    }

    public static class UriBuilderCustom
    {
        public static string ToFullUrl(this Uri uri, string roadName)
        {
            string url = $"https://api.tfl.gov.uk/Road/{roadName}";
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["app_id"] = ConfigurationManager.AppSettings.Get("app_id");
            query["app_key"] = ConfigurationManager.AppSettings.Get("app_key");
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

    }
}
