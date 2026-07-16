using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands.Category;
using Product.Application.DTOs;
using Product.Application.Interface;


namespace ProductService.Controllers;
// [Authorize] -- Test !!
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMediator _mediator;

    public CategoryController(ICategoryService categoryService, IMediator mediator)
    {
        _categoryService = categoryService;
        _mediator = mediator;
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
    public async Task<ActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
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