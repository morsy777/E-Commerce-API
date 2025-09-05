using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public class ShoppingCartService(AppDbContext context) : IShoppingCartService
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddProductToCartAsync(int userId, int productId, int quantity,
        CancellationToken cancellationToken = default)
    {
        //if (!_context.Products.Any(p => p.ProductId == productId))
        //    return false;

        //var shoppingCart = await _context.ShoppingCarts
        //    .Include(c => c.CartItems)
        //    .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        //if(shoppingCart is null)
        //{
        //    shoppingCart = new ShoppingCart()
        //    {
        //        UserId = userId,
        //        CartItems = new List<CartItem>()
        //    };

        //    _context.ShoppingCarts.Add(shoppingCart);
        //}

        //var existingCartProduct = shoppingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        //if (existingCartProduct is not null)
        //{
        //    existingCartProduct.Quantity += quantity;
        //}
        //else
        //{
        //    var newCartProduct = new CartItem()
        //    {
        //        ProductId = productId,
        //        Quantity = quantity,
        //    };

        //    shoppingCart.CartItems.Add(newCartProduct);
        //}

        //await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


}
