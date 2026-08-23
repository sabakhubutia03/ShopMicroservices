using MediatR;
using Order.Application.DTOs;
using Order.Application.Interface;
using Order.Domain.Exceptions;

namespace Order.Application.Queries.GetOrderId;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery , OrderResponseDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<OrderResponseDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var getOrderById = await _orderRepository.GetById(request.Id);
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
}