using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Admin.Core.Library.Entity
{

    /// <summary>
    /// Keyword entity for Pormotional documents
    /// </summary>
    public class KeywordTags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int KeywordId { get; set; } 
        public string KeywordCode { get; set; }
        [Required]
        public string KeywordName { get; set; }

        //Common Properties
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
