using AutoMapper;
using E_Commerce.BLL.DTOs.Orders;
using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Mapping;

public class OrderMap: Profile
{
    public OrderMap()
    {
        CreateMap<OrderRequestDto, Order>();

        CreateMap<Order, OrderResponseDto>()
            .ForMember(dest => dest.Products, 
                opt => opt.MapFrom(src => src.OrderItems.Select(oi => oi.Product)));
    }
}
