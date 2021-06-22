using Admin.Core.Library.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Admin.Core.Library.Repository
{
    /// <summary>
    /// Implementation of Admin interfaces
    /// </summary>
    public class AdminRepository : IAdminRepository
    {

        private readonly AdminDbContext _dbContext;
        private readonly string _user;
        /// <summary>
        /// Constructor to initiate DB Context
        /// </summary>
        /// <param name="adminDbContext"></param>
        public AdminRepository(AdminDbContext adminDbContext)
        {
            _dbContext = adminDbContext;
            _user = "WebUser";
        }

        /// <summary>
        /// Add new Keyword to Product and Accessories
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="keyword">Keyword Name</param>
        /// <returns>Success or Failure flag</returns>
        public bool AddKeyword(int productId, string keyword)
        {
            if (productId == null) { throw new ArgumentNullException("productId"); }
            if (string.IsNullOrEmpty(keyword)) { throw new ArgumentNullException("keyword"); }

            KeywordTags keywordTags = new KeywordTags();

            //If entered Keyword exists already in data store find the entity and update product mapping 
            if (_dbContext.KeywordTags.Any(k => k.KeywordName.ToLower() == keyword.ToLower()))
            {
                keywordTags = _dbContext.KeywordTags.FirstOrDefault(k => k.KeywordName == keyword);
            }
            //else create new Keyword and update product mapping
            else
            {
                keywordTags = new KeywordTags()
                {
                    KeywordName = keyword,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    CreatedBy = _user
                };

                _dbContext.KeywordTags.Add(keywordTags);
                _dbContext.SaveChanges();
            }


            if (!_dbContext.ProductKeywords.Any(k => k.KeywordId == keywordTags.KeywordId
            && k.ProductId == productId))
            {
                //Finally create a new entry in mapping table
                ProductKeywords productKeywords = new ProductKeywords()
                {
                    ProductId = productId,
                    KeywordId = keywordTags.KeywordId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    CreatedBy = _user,
                };

                _dbContext.ProductKeywords.Add(productKeywords);
            }


            return SaveEF();
        }

        /// <summary>
        /// Remove Keyword from Product and Accessories
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="keywordId">Keyword Id</param>
        /// <returns>Success or Failure flag</returns>
        public bool DeleteKeyword(int productId, int keywordId)
        {
            if (productId == null) { throw new ArgumentNullException("productId"); }
            if (keywordId == null) { throw new ArgumentNullException("keywordId"); }

            //Check if tag isused in more than one product
            if (_dbContext.ProductKeywords.Where(k => k.KeywordId == keywordId).Count() > 1)
            {
                //delete ProductKeywords entry
                _dbContext.ProductKeywords.Remove(_dbContext.ProductKeywords.Single(pk => pk.ProductId
                == productId && pk.KeywordId == keywordId));
                //SaveEF();
            }
            else if (_dbContext.ProductKeywords.Where(k => k.KeywordId == keywordId
            && k.ProductId == productId
            ).Count() == 1)
            {
                //delete ProductKeywords entry
                _dbContext.ProductKeywords.Remove(_dbContext.ProductKeywords.Single(pk => pk.ProductId
                == productId && pk.KeywordId == keywordId));
                //delete entry in master keyword table
                _dbContext.KeywordTags.Remove(_dbContext.KeywordTags.Single(
                    k => k.KeywordId == keywordId
                    ));
                //SaveEF();
            }

            return SaveEF();
        }

        /// <summary>
        /// Get all Products and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of Products</returns>
        public ICollection<Product> GetProducts()
        {
            return _dbContext.Products.Include(p=>p.ProductKeywords).Where(p => p.IsDeleted == false).ToList();
        }

        /// <summary>
        /// Get all Products associated with given list of keywords
        /// </summary>
        /// <param name="keywords">One or more Keywords</param>
        /// <returns>List of Products</returns>
        public ICollection<Product> GetProducts(int[] keywordIds)
        {
            //return _dbContext.Products.Include(p => p.ProductKeywords).Where(p => p.IsDeleted == false).ToList();
            //var keywordIdList = _dbContext.KeywordTags.Where(p => p.IsDeleted == false
            //&& keywords.Contains(p.KeywordName)
            //).ToList();

            var objList = _dbContext.Products.Include(p
                => p.ProductKeywords).Where(p => p.IsDeleted == false && p.ProductKeywords.Any(pk=>keywordIds.Contains(pk.KeywordId)))
                .ToList();

            return objList;

        }


        /// <summary>
        /// Get Product by product id supplied
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <returns>Product</returns>
        public Product GetProduct(int productId)
        {
            //return _dbContext.Products.Include(p => p.ProductKeywords).Where(p => p.IsDeleted == false).ToList();
            //var keywordIdList = _dbContext.KeywordTags.Where(p => p.IsDeleted == false
            //&& keywords.Contains(p.KeywordName)
            //).ToList();

            var objList = _dbContext.Products.Include(p
                => p.ProductKeywords).Where(p => p.IsDeleted == false && p.ProductId == productId).SingleOrDefault();

            return objList;

        }


        /// <summary>
        /// Update EF
        /// </summary>
        /// <returns>Success or Failure flag</returns>
        public bool SaveEF()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }


        /// <summary>
        /// Get all Product Keywords and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of ProductKeywords</returns>
        public ICollection<ProductKeywords> GetProductKeywords()
        {
            return _dbContext.ProductKeywords.Where(p => p.IsDeleted == false).ToList();
        }

        /// <summary>
        /// Get all Keywords and Accessories along with keywords associated
        /// </summary>
        /// <returns>List of Keywords</returns>
        public ICollection<KeywordTags> GetKeywordTags()
        {
            return _dbContext.KeywordTags.Where(p => p.IsDeleted == false).ToList();
        }
    }
}
