using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interface;


namespace ProductService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> Get()
    {
        var categoryGetAll = await _categoryService.GetAllCategories();
        return Ok(categoryGetAll);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<CategoryResponseDto>> Get(int id)
    {
        var categoryGet = await _categoryService.GetCategoryById(id);
        return Ok(categoryGet);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CategoryCreateDto dto)
    {
        var create = await _categoryService.CreateCategory(dto);
        return CreatedAtAction(nameof(Get), new { id = create.Id }, create);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, CategoryUpdateDto dto)
    {
        var update = await _categoryService.UpdateCategory(id, dto);
        return Ok(update);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }
}