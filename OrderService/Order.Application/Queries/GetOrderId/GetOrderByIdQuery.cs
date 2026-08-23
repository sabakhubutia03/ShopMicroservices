using MediatR;
using Order.Application.DTOs;

namespace Order.Application.Queries.GetOrderId;

public record GetOrderByIdQuery (int Id): IRequest<OrderResponseDto>;