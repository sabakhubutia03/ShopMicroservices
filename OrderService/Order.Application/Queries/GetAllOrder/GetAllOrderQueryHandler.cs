using MediatR;
using Order.Application.DTOs;
using Order.Application.Interface;

namespace Order.Application.Queries.GetAllOrder;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery , IEnumerable<OrderResponseDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<IEnumerable<OrderResponseDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var getAllOrder = await _orderRepository.GetAll();
        return getAllOrder.Select(n => new OrderResponseDto
        {
            Id = n.Id,
            Price = n.Price,
            Quantity = n.Quantity, 
            UserId = n.UserId, 
            ProductId = n.ProductId,
            TotalPrice = n.TotalPrice, 
            Date = n.Date
        });
    }
}
