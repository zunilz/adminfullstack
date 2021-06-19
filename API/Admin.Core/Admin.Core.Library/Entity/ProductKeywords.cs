using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Admin.Core.Library.Entity
{
    /// <summary>
    /// Mapping of Product and Keywords
    /// </summary>
    public class ProductKeywords
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductKeywordsId { get; set; } 

        public bool IsActive { get; set; }

        //Common Properties
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int KeywordId { get; set; }

    }
}
