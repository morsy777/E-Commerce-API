using E_Commerce.BLL.DTOs.Orders;
using E_Commerce.BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public interface IOrderService
{
    Task<bool> CheckoutAsync(string userId, CancellationToken cancellationToken);
}
