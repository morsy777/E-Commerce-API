using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService category) : ControllerBase
{
    private readonly ICategoryService _categoryService = category;


    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var Categories = await _categoryService.GetCategoriesAsync(cancellationToken);

        if (!Categories.Any())
            return NotFound();

        return Ok(Categories);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken = default)
    {
        var Category = await _categoryService.GetCategoryByIdAsync(Id, cancellationToken);

        if (Category is null)
            return NotFound();

        return Ok(Category);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]

    [HttpPost("AddCategory")]
    public async Task<IActionResult> Add(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken = default)
    {
        var newCategory = await _categoryService.AddAsync(categoryRequestDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = newCategory.CategoryId }, newCategory);
    }


    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(int Id, [FromForm] CategoryRequestDto categoryDto, CancellationToken cancellationToken = default)
    {
        var isUpdated = await _categoryService.UpdateAsync(Id, categoryDto, cancellationToken);

        return isUpdated ? NoContent() : NotFound($"Category with id {Id} not found.");
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
    {
        var isDeleted = await _categoryService.DeleteAsync(Id, cancellationToken);

        return isDeleted ? NoContent() : NotFound($"Product with id {Id} not found.");
    }



}
