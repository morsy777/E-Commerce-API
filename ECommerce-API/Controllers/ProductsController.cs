namespace ECommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("GetAllProucts")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductsAsync(cancellationToken);

        if(!products.Any())
            return NotFound();

        return Ok(products);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetProductByIdAsync(Id, cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]

    [HttpPost("AddProdcut")]
    public async Task<IActionResult> Add(ProductRequestDto productRequestDto, CancellationToken cancellationToken = default)
    {
        var newProduct = await _productService.AddAsync(productRequestDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(int Id, [FromForm] ProductRequestDto productDto, CancellationToken cancellationToken = default)
    {
        var isUpdated = await _productService.UpdateAsync(Id, productDto, cancellationToken);

        return isUpdated ? NoContent() : NotFound($"Product with id {Id} not found.");
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
    {
        var isDeleted = await _productService.DeleteAsync(Id, cancellationToken);

        return isDeleted ? NoContent() : NotFound($"Product with id {Id} not found.");
    }


    [ProducesResponseType(StatusCodes.Status200OK)]

    [HttpGet("Search")]
    public async Task<IActionResult> Search([FromQuery] string title, CancellationToken cancellationToken)
    {
        var products = await _productService.SearchByNameAsync(title, cancellationToken);
        return Ok(products);
    }
    

}
