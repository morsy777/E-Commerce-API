using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService order) : ControllerBase
{
    private readonly IOrderService _order = order;

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("PlaceOrder/{Id}")]
    public async Task<IActionResult> PlaceOrder(string Id, CancellationToken cancellationToken = default)
    {
        bool isPlaced = await _order.CheckoutAsync(Id, cancellationToken);
        return (isPlaced) ? NoContent() : BadRequest();
       
    }
}
