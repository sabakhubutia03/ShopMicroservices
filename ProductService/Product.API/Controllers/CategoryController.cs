using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands.Category;
using Product.Application.Commands.Category.UpdateCategory;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Application.Queries.GetCategory;
using Product.Application.Queries.GetCategoryById;


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
    public async Task<ActionResult> GetAllCategories()
    {
        var query = new GetCategoryQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCategoryById(int id)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCategory(int id, UpdateCategoryRequest request)
    {
        var command = new UpdateCategoryCommand(id, request.Name);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }
}