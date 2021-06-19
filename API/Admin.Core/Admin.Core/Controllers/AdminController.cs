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
        /// <returns></returns>
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
        /// Get all Keywords in Data Store
        /// </summary>
        /// <returns></returns>
        [HttpGet("keywords")]
        public IActionResult GetKeywords()
        {
            List<KeywordTags> objList = new List<KeywordTags>();
            objList = _adminRepository.GetKeywordTags().ToList();
            List<KeywordTagsDto> objDto = new List<KeywordTagsDto>();

            objDto = _mapper.Map<List<KeywordTags>, List<KeywordTagsDto>>(objList);

            return Ok(objDto);
        }



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


        [HttpDelete("keyword/update")]
        public IActionResult DeleteKeyword([FromBody] KeywordRequest keywordRequest)
        {
            if (keywordRequest == null) { return BadRequest(); }
            if (keywordRequest.KeywordId == null) { return BadRequest(); }
            if (keywordRequest.ProductId == null) { return BadRequest(); }
            if (string.IsNullOrEmpty(keywordRequest.Keyword) == null) { return BadRequest(); }

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
    }
}
