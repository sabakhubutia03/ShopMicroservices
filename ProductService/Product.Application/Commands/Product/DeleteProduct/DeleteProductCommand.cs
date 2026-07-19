using MediatR;

namespace Product.Application.Commands.Product.DeleteProduct;

public record DeleteProductCommand (int Id ) : IRequest<Unit>;