using AutoMapper;
using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Mapping;
public class ProductMap : Profile
{
    public ProductMap()
    {
        CreateMap<ProductRequestDto, Product>()
            .ForMember(dest => dest.Image, opt => opt.Ignore()); 

        CreateMap<Product, ProductResponseDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category != null ? src.Category.Title : string.Empty))
            .ForMember(dest => dest.Image,
                       opt => opt.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image) : null));
    }
}
