using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MamaApp.Models
{
    public class Source
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string SourceName { get; set; }
    }
}
