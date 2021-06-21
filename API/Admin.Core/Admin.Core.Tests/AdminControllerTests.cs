using Admin.Core.Controllers;
using Admin.Core.Library.Entity;
using Admin.Core.Library.Repository;
using Admin.Core.Mapper;
using Admin.Core.Models;
using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Admin.Core.Tests
{
    public class AdminControllerTest
    {
        /// <summary>
        /// Testing response from Products API  
        /// </summary>
        [Fact]
        public void GetProducts_Return_Products_Test()
        {
            var fakeProducts = A.CollectionOfDummy<Product>(5).ToList();
            var repo = A.Fake<IAdminRepository>();
            //auto mapper configuration
            AdminMappings am = new AdminMappings();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AdminMappings());
            });
            var mapper = mockMapper.CreateMapper();



            A.CallTo(() => repo.GetProducts()).Returns(fakeProducts);
            var controller = new AdminController(null, mapper, repo);
            var result = controller.GetProducts();



            var resultOk = result as OkObjectResult;
            var resultProducts = resultOk.Value as IEnumerable<ProductDto>;

            var fakeProductsMapped = mapper.Map<List<Product>, List<ProductDto>>(fakeProducts) as IEnumerable<ProductDto>;

            var fakeProductsMappedStr = JsonConvert.SerializeObject(fakeProductsMapped);
            var resultProductsStr = JsonConvert.SerializeObject(resultProducts);

            Assert.Equal(fakeProductsMappedStr, resultProductsStr); 

        }
    }
}
