using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands.Product.Create;
using Product.Application.Commands.Product.DeleteProduct;
using Product.Application.Commands.Product.UpdateProduct;
using Product.Application.Queries.Product.GetAllProdcut;
using Product.Application.Queries.Product.GetByIdProduct;

namespace ProductService.Controllers;
// [Authorize] -- TEST  
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProdcutQuery());
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetByIdProductQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProdcut(int id , UpdateProdcutCommand command)
    {
        var commandWith = command with { Id = id };
        var result = await _mediator.Send(commandWith);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var delete = new DeleteProductCommand(id);
        await _mediator.Send(delete);
        return NoContent();
    }
}