﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MamaApp.Models;
using NewsAPI;
using Newtonsoft.Json;

namespace MamaApp.Utility
{
    public static class ServiceUtility
    {
        private static HttpClient client;

        private static string webUrl = "https://newsapi.org";

        private static void InitHttpClient()
        {
            client = new HttpClient(
                new HttpClientHandler {ClientCertificateOptions = ClientCertificateOption.Automatic})
            {
                BaseAddress = new Uri(webUrl)
            };


            var newsApiClient = new NewsApiClient("26523bd197a0401593a2f3cd44841ccb");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        }

        public static async Task<Result> GetNews()
        {
            InitHttpClient();

            try
            {
                var response = await client.GetAsync("/v2/top-headlines?country=ro&apiKey=26523bd197a0401593a2f3cd44841ccb");

                if (response.IsSuccessStatusCode)
                {
                    var newsResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Result>(newsResponse);
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

    }
}
