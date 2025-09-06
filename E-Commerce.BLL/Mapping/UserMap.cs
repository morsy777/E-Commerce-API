using AutoMapper;
using E_Commerce.BLL.DTOs.User;
using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Mapping;
public class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<ApplicationUser, UserResponseDto>();
    }
}
