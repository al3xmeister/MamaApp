using System;
using System.Collections.Generic;
using System.Text;
using NewsAPI.Models;
using Newtonsoft.Json;

namespace MamaApp.Models
{
    
    public class article
    {
        public Source Source { get; set; }
        [JsonProperty("author")]
        public string ziar { get; set; }
        [JsonProperty("title")]
        public string Headline { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }

        
        public DateTime? PublishedAt { get; set; }
        public string content { get; set; }
    }
}
