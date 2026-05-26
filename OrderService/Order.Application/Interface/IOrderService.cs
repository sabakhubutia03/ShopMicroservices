using Order.Application.DTOs;

namespace Order.Application.Interface;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetAllOrders();
    Task<OrderResponseDto> GetOrderById(int id);
    Task<OrderResponseDto> Create (OrderCreateDto orderCreateDto);
    Task<OrderResponseDto> Update (int id , OrderUpdateDto orderUpdateDto);
    Task Delete (int id);
}