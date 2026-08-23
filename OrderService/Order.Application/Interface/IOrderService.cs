using Order.Application.DTOs;

namespace Order.Application.Interface;

public interface IOrderService
{
    Task<OrderResponseDto> Update (int id , OrderUpdateDto orderUpdateDto);
    Task Delete (int id);
}