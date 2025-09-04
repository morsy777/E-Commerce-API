using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingCartsController(IShoppingCartService shoppingCart) : ControllerBase
{
    private readonly IShoppingCartService _shoppingCart = shoppingCart;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpPost("AddtoShoopingCart")]
    public async Task<IActionResult> Add(int userId,int productId,int quantity = 1, CancellationToken cancellationToken = default)
    {
        bool isAdded = await _shoppingCart.AddProductToCartAsync(userId, productId, quantity, cancellationToken);

        if (isAdded)
            return Ok("Added Successfuly");

        return BadRequest();
    }
}
