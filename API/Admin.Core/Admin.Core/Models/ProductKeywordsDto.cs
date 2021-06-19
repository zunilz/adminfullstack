using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core.Models
{
    public class ProductKeywordsDto
    {
        public int ProductKeywordsId { get; set; }

        public bool IsActive { get; set; }
  
        public int ProductId { get; set; }
 
        public int KeywordId { get; set; }
    }
}
