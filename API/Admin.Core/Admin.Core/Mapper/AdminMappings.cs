using Admin.Core.Library.Entity;
using Admin.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core.Mapper
{
    public class AdminMappings: Profile
    {
        public AdminMappings()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<KeywordTags, KeywordTagsDto>().ReverseMap();
            CreateMap<ProductKeywords, ProductKeywordsDto>().ReverseMap();
        }
    }
}
