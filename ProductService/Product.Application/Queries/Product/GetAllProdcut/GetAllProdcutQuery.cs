using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Queries.Product.GetAllProdcut;

public record GetAllProdcutQuery : IRequest<List<ProductResponseDto>>;