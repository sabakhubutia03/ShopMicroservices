using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Commands.CreateOrder;
using Order.Application.DTOs;
using Order.Application.Interface;
using Order.Application.Queries.GetAllOrder;
using Order.Application.Queries.GetOrderId;

namespace Order.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMediator _mediator;

    public OrderController(IOrderService orderService, IMediator mediator)
    {
        _orderService = orderService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllOrderQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    { 
        var query = new GetOrderByIdQuery(id);
        var reuslt = await _mediator.Send(query);
        return Ok(reuslt);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
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