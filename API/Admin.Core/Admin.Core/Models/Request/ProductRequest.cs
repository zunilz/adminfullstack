using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core.Models.Request
{
    public class ProductRequest
    { 
         
        [JsonProperty("keywordids")]
        public int[] KeywordIds { get; set; }

        [JsonProperty("productid")]
        public int ProductId { get; set; }
    }
}
