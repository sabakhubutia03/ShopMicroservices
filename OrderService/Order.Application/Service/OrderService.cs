using Microsoft.Extensions.Configuration;
using Order.Application.DTOs;
using Order.Application.Interface;
using Order.Domain.Exceptions;

namespace Order.Application.Service;

public class OrderService : IOrderService
{  
    private readonly IOrderRepository _orderRepository;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration  _configuration;

    public OrderService(IOrderRepository orderRepository, HttpClient httpClient, IConfiguration configuration)
    {
        _orderRepository = orderRepository;
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<OrderResponseDto> Update(int id, OrderUpdateDto orderUpdateDto)
    {
        var getOrderById = await _orderRepository.GetById(id);
        if (getOrderById == null)
        {
            throw new ApiException(
                "Invalid order id",
                "NotFound",
                404,
                "Order not found",
                "Order not found"
            );
        }

        if (orderUpdateDto.Price != null)
        {
            getOrderById.Price = orderUpdateDto.Price.Value;
        }

        if (orderUpdateDto.Quantity != null)
        {
            getOrderById.Quantity = orderUpdateDto.Quantity.Value;
        }
        
        getOrderById.TotalPrice = getOrderById.Price * getOrderById.Quantity;
        
        await _orderRepository.Update(getOrderById);

        return new OrderResponseDto
        {
            Id = getOrderById.Id,
            Price = getOrderById.Price,
            ProductId = getOrderById.ProductId,
            Quantity = getOrderById.Quantity,
            TotalPrice = getOrderById.TotalPrice,
            UserId = getOrderById.UserId,
            Date = getOrderById.Date
        };
    }

    public async Task Delete(int id)
    {
        var deleteId = await _orderRepository.GetById(id);
        if (deleteId == null)
        {
            throw new ApiException(
                "Invalid order id",
                "BadRequest",
                400,
                "BadRequest",
                "Order not found"
            );
        }
        await _orderRepository.Delete(deleteId);
    }
}