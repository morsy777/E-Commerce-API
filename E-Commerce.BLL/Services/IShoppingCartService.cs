using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public interface IShoppingCartService
{
    Task<bool> AddProductToCartAsync(int userId, int productId, int quantity = 1, CancellationToken cancellationToken = default);
}
