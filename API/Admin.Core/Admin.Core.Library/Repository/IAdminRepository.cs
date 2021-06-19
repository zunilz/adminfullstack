using Admin.Core.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Core.Library.Repository
{
    /// <summary>
    /// Repo inetrface containing signature of all Admin panel related functions
    /// </summary>
    public interface IAdminRepository
    {
        /// <summary>
        /// Get all Products and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of Products</returns>
        ICollection<Product> GetProducts();

        /// <summary>
        /// Get all Products associated with given list of keywords
        /// </summary>
        /// <param name="keywords">One or more Keywords</param>
        /// <returns>List of Products</returns>
        ICollection<Product> GetProducts(string[] keywords);
        /// <summary>
        /// Add new Keyword to Product and Accessories
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="keyword">Keyword Name</param>
        /// <returns>Success or Failure flag</returns>
        bool AddKeyword(int productId, string keyword);
        /// <summary>
        /// Remove Keyword from Product and Accessories
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="keywordId">Keyword Id</param>
        /// <returns>Success or Failure flag</returns>
        bool DeleteKeyword(int productId, int keywordId);

        /// <summary>
        /// Update EF
        /// </summary>
        /// <returns>Success or Failure flag</returns>
        bool SaveEF();

        /// <summary>
        /// Get all Product Keywords and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of ProductKeywords</returns>
        public ICollection<ProductKeywords> GetProductKeywords();
       
        /// <summary>
        /// Get all Keywords and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of Keywords</returns>
        public ICollection<KeywordTags> GetKeywordTags();
    }
}
