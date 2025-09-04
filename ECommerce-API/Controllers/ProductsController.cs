

namespace ECommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductsAsync(cancellationToken);

        if(products is null)
            return NotFound();

        return Ok(products);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetProductByIdAsync(Id, cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost("")]
    public async Task<IActionResult> Add(ProductRequestDto productRequestDto, CancellationToken cancellationToken = default)
    {
        var newProduct = await _productService.AddAsync(productRequestDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(int Id, [FromForm] ProductRequestDto productDto, CancellationToken cancellationToken = default)
    {
        var isUpdated = await _productService.UpdateAsync(Id, productDto, cancellationToken);

        return isUpdated ? NoContent() : NotFound($"Product with id {Id} not found.");
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
    {
        var isDeleted = await _productService.DeleteAsync(Id, cancellationToken);

        return isDeleted ? NoContent() : NotFound($"Product with id {Id} not found.");
    }

    [HttpGet("Search")]
    public async Task<IActionResult> Search([FromQuery] string title, CancellationToken cancellationToken)
    {
        var products = await _productService.SearchByNameAsync(title, cancellationToken);
        return Ok(products);
    }
}
