using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core.Models.Request
{
    public class KeywordRequest
    {
        [JsonProperty("productid")]
        public int ProductId { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("keywordid")]
        public int KeywordId { get; set; }
    }
}
