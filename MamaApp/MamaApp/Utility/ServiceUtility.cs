using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MamaApp.Models;
using Newtonsoft.Json;

namespace MamaApp.Utility {
    public static class ServiceUtility {
        private static HttpClient client;

        private static string webUrl = "https://newsapi.org/v2/top-headlines?country=ro&apiKey=514376a3e0ee44229f62f33a236b69b0";

        private static void InitHttpClient() {
            client = new HttpClient(
                new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic }) {
                BaseAddress = new Uri(webUrl)
            };


            // var newsApiClient = new NewsApiClient("26523bd197a0401593a2f3cd44841ccb");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
         private const string url = "https://jsonplaceholder.typicode.com/posts";

        
        //public static async Task<Result> GetNews() {
        //    InitHttpClient();

        //    try {


        //        var response = await client.GetStringAsync(url);

        //        var max = JsonConvert.DeserializeObject<Result>(response);
        //        return max;
        //    } catch {
        //        return null;
        //    }
        //}

    }

}
