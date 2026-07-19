using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Queries.Product.GetByIdProduct;

public record GetByIdProductQuery (int Id) : IRequest<ProductResponseDto>;