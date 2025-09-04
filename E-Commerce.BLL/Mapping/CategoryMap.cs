using AutoMapper;
using E_Commerce.BLL.DTOs.Category;
using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;


namespace E_Commerce.BLL.Mapping;

public class CategoryMap : Profile
{
    public CategoryMap()
    {
        CreateMap<CategoryRequestDto, Category>()
            .ForMember(dest => dest.ImageData, opt => opt.Ignore());

        CreateMap<Category, CategoryResponseDto>()
            .ForMember(dest => dest.relatedProducts, opt => opt.MapFrom(src => src.Products))
            .ForMember(dest => dest.ImageData,
                       opt => opt.MapFrom(src => src.ImageData != null ? Convert.ToBase64String(src.ImageData) : null)); ;

    }
}
