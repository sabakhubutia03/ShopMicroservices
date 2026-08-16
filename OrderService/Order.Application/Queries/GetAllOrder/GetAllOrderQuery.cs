using MediatR;
using Order.Application.DTOs;

namespace Order.Application.Queries.GetAllOrder;

public record GetAllOrderQuery : IRequest<IEnumerable<OrderResponseDto>>;