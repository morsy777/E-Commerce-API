using E_Commerce.BLL.DTOs.Product;
using E_Commerce.BLL.DTOs.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public interface IShoppingCartService
{
    Task<bool> AddProductToCartAsync(string userId, int productId, int quantity = 1, CancellationToken cancellationToken = default);
    Task<IEnumerable<CartResponseDto>> GetProductCartByUserId(string userId, CancellationToken cancellationToken = default);
    Task<bool> RemoveProductCartByProductId(string userId, int productId, CancellationToken cancellationToken = default);
}
