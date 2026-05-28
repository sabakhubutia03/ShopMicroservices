using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interface;

namespace ProductService.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        var response = await _productService.GetAllProducts();
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var response = await _productService.GetProductById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductCreateDto dto)
    {
        var createdProduct = await _productService.CreateProduct(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ProductUpdateDto dto)
    {
        var updatedProduct = await _productService.UpdateProduct(id, dto);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.DeleteProduct(id);
        return NoContent();
    }
}