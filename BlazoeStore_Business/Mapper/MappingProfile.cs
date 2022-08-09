using AutoMapper;
using BlazorStore_DataAccess;
using BlazorStore_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeStore_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<CategoryDto, Category>();
        }
    }
}
