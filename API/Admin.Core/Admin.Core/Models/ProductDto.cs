using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }

        //public List<KeywordTagsDto> KeywordTags { get; set; }
        public List<ProductKeywordsDto> ProductKeywords { get; set; }
    }
}
