using Order.Application.DTOs;
using Order.Application.Interface;

namespace Order.Application.Service;

public class OrderService : IOrderService
{  
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task<IEnumerable<OrderResponseDto>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponseDto> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponseDto> Create(OrderCreateDto orderCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponseDto> Update(int id, OrderUpdateDto orderUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}