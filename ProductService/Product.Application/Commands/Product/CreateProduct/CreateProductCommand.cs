using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Commands.Product.Create;

public record CreateProductCommand (
    string Name ,
    Decimal Price,
    int CategoryId ,
    int Stock ,
    DateTime Created) : IRequest<ProductResponseDto>;