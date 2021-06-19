using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Admin.Core.Library.Entity
{
    /// <summary>
    /// Mapping of Product and Accessory products to it
    /// </summary>
    public class ProductAccessories
    {
        [Key]
        public int ProductAccessoryId { get; set; }
        public int ProductId { get; set; }
        public int AccessoryProductId { get; set; }
        public bool IsActive { get; set; }

        //Common Properties
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }



    }
}
