using E_Commerce.BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetUsersAsync(CancellationToken cancellationToken);
}
