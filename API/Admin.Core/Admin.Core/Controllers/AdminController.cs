using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Core.Library.Entity;
using Admin.Core.Library.Repository;
using Admin.Core.Models;
using Admin.Core.Models.Request;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Admin.Core.Controllers
{
    //[Route("api/[controller]")]
    [Route("adminapi")]
    [ApiController]
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger Object</param>
        /// <param name="mapper">Mapper Object</param>
        /// <param name="adminRepository">Repo Object</param>
        public AdminController(ILogger<AdminController> logger
            ,IMapper mapper
            ,IAdminRepository adminRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _adminRepository = adminRepository;
        }


        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            List<Product> objList = new List<Product>();
            objList = _adminRepository.GetProducts().ToList();
            List<ProductDto> objDto = new List<ProductDto>();

            objDto = _mapper.Map<List<Product>, List<ProductDto>>(objList);

            return Ok(objDto);
        }


        /// <summary>
        /// Get All Products based on supplied keywords
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpPost("products")]
        public IActionResult GetProducts([FromBody] ProductRequest productRequest)
        {
            List<Product> objList = new List<Product>();
            objList = _adminRepository.GetProducts(productRequest.KeywordIds).ToList();
            List<ProductDto> objDto = new List<ProductDto>();

            objDto = _mapper.Map<List<Product>, List<ProductDto>>(objList);

            return Ok(objDto);
        }



        /// <summary>
        /// Get Product based on supplied product id
        /// </summary>
        /// <returns>Product</returns>
        [HttpPost("product")]
        public IActionResult GetProduct([FromBody] ProductRequest productRequest)
        {
            Product objProd = new Product();
            objProd = _adminRepository.GetProduct(productRequest.ProductId);
            ProductDto objDto = new ProductDto();

            objDto = _mapper.Map<Product, ProductDto>(objProd);

            return Ok(objDto);
        }


        /// <summary>
        /// Get all Keywords in Data Store
        /// </summary>
        /// <returns>List of Keywords</returns>
        [HttpGet("keywords")]
        public IActionResult GetKeywords()
        {
            List<KeywordTags> objList = new List<KeywordTags>();
            objList = _adminRepository.GetKeywordTags().ToList();
            List<KeywordTagsDto> objDto = new List<KeywordTagsDto>();

            objDto = _mapper.Map<List<KeywordTags>, List<KeywordTagsDto>>(objList);

            return Ok(objDto);
        }


        /// <summary>
        /// Adds new keyword in Data store
        /// </summary>
        /// <param name="keywordRequest">Request body</param>
        /// <returns>Http succes/failure response</returns>
        [HttpPost("keyword/add")]
        public IActionResult AddKeyword([FromBody] KeywordRequest keywordRequest)
        {
            if (keywordRequest == null) { return BadRequest(); }
            if (string.IsNullOrEmpty(keywordRequest.Keyword)) { return BadRequest(); } 

            try
            {
                var result = _adminRepository.AddKeyword(keywordRequest.ProductId, keywordRequest.Keyword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }

        }


        /// <summary>
        /// Updates existing keyword in Data store
        /// </summary>
        /// <param name="keywordRequest">Request body</param>
        /// <returns>Http succes/failure response</returns>
        [HttpPost("keyword/update")]
        public IActionResult UpdateKeyword([FromBody] KeywordRequest keywordRequest)
        {
            if (keywordRequest == null) { return BadRequest(); } 
            if (string.IsNullOrEmpty(keywordRequest.Keyword)) { return BadRequest(); }

            try
            {
                var resultDelete = _adminRepository.DeleteKeyword(keywordRequest.ProductId, keywordRequest.KeywordId);
                var resultAdd = _adminRepository.AddKeyword(keywordRequest.ProductId, keywordRequest.Keyword);
                return Ok(resultAdd);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }

        }


        /// <summary>
        /// Deletes keyword from Data store
        /// </summary>
        /// <param name="keywordRequest">Request body</param>
        /// <returns>Http succes/failure response</returns>
        [HttpDelete("keyword/delete")]
        public IActionResult DeleteKeyword([FromBody] KeywordRequest keywordRequest)
        {
            if (keywordRequest == null) { return BadRequest(); } 

            try
            {
                var resultDelete = _adminRepository.DeleteKeyword(keywordRequest.ProductId, keywordRequest.KeywordId); 
                return Ok(resultDelete);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }

        }
    }
}
