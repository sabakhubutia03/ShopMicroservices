using MediatR;
using Order.Application.DTOs;

namespace Order.Application.Commands.CreateOrder;

public record CreateOrderCommand (
    int UserId, 
    int ProductId,
    decimal Price,
    int Quantity ): IRequest<OrderResponseDto>;