using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MamaApp.Models
{
    public class Result
    {
        public string status { get; set; }
        public int? totalResults { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        
    }
}
