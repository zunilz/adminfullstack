using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Core.Library.Entity
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        public bool IsActive { get; set; }

        //Guid pointing to Promo Doc
        public string PromDocumentCode { get; set; }

        //Common Properties
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public List<ProductKeywords> ProductKeywords{ get; set; }
    }
}
