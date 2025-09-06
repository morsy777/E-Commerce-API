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

    [HttpGet("GetProductsDetails/{Id}")]
    public async Task<IActionResult> GetOrderProductDetails(string Id, int orderId, CancellationToken cancellationToken = default)
    {
        var orderProducts = await _order.GetOrderProductsDetailsAsync(Id, orderId, cancellationToken);

        return orderProducts.Any() ? Ok(orderProducts) : BadRequest($"There is no Products in this order {orderId}");
    }

    [HttpGet("GetUserOrders/{Id}")]
    public async Task<IActionResult> GetUserOrders(string Id, CancellationToken cancellationToken = default)
    {
        var userOrders = await _order.GetUserOrdersAsync(Id, cancellationToken);

        return userOrders.Any() ? Ok(userOrders) : BadRequest();
    }

    [HttpDelete("DeleteUserOrder/{Id}")]
    public async Task<IActionResult> DeleteUserOrder(string Id, int orderId, CancellationToken cancellationToken = default)
    {
        var userOrders = await _order.RemoveUserOrderAsync(Id, orderId, cancellationToken);

        return userOrders ? NoContent() : BadRequest();
    }

    [HttpDelete("ClearUserOrders/{Id}")]
    public async Task<IActionResult> ClearUserOrders(string Id,CancellationToken cancellationToken = default)
    {
        var userOrders = await _order.RemoveUserAllOrdersAsync(Id, cancellationToken);

        return userOrders ? NoContent() : BadRequest();
    }











}
