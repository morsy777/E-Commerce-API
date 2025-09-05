using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingCartsController(IShoppingCartService shoppingCart) : ControllerBase
{
    private readonly IShoppingCartService _shoppingCart = shoppingCart;

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpPost("AddtoShoopingCart")]
    public async Task<IActionResult> AddProductToCart(string userId,int productId,int quantity = 1, CancellationToken cancellationToken = default)
    {
        bool isAdded = await _shoppingCart.AddProductToCartAsync(userId, productId, quantity, cancellationToken);

        if (isAdded)
            return NoContent();

        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("GetAllShoppingCart")]
    public async Task<IActionResult> GetShoppingCartByUserId(string userId, CancellationToken cancellationToken = default)
    {
        var cartProducts = await _shoppingCart.GetProductCartByUserId(userId, cancellationToken);

        if(cartProducts is null)
            return NotFound();

        return Ok(cartProducts);

    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    [HttpDelete("RemoveFromCart/{Id}")]
    public async Task<IActionResult> RemoveProductFromCart(string Id, int ProductId ,CancellationToken cancellationToken = default)
    {
        bool isDeleted = await _shoppingCart.RemoveProductCartByProductId(Id, ProductId, cancellationToken);

        return (isDeleted)?  NoContent() : NotFound();
    }
}
