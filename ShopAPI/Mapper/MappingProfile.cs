using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.DTOs;
using ShopAPI.Models;

namespace ShopAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductCreateDto, Product>();


            CreateMap<Category, CategoryDto>();


            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
