using Microsoft.AspNetCore.Mvc;
using Order.Application.DTOs;
using Order.Application.Interface;

namespace Order.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<OrderResponseDto>> GetAll()
    {
        var ordersAll = await _orderService.GetAllOrders();
        return Ok(ordersAll);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponseDto>> GetOrderId(int id)
    {
        var orderId = await _orderService.GetOrderById(id);
        return Ok(orderId);
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> Create(OrderCreateDto createDto)
    {
        var create = await _orderService.Create(createDto);
        return CreatedAtAction(nameof(GetOrderId), new { id = create.Id }, create);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id ,OrderUpdateDto updateDto)
    {
        var update = await _orderService.Update(id, updateDto);
        return Ok(update);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _orderService.Delete(id);
        return NoContent();
    }
}