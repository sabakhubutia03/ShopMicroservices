using System.Text.Json.Serialization;
using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Commands.Product.UpdateProduct;

public record UpdateProdcutCommand (
   [property: JsonIgnore] int Id ,
    string Name,
    int Stock,
    Decimal Price) : IRequest<ProductResponseDto>;