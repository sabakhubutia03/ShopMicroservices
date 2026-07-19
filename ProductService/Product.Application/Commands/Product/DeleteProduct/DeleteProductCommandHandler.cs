using MediatR;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Product.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand , Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _productRepository.GetById(request.Id);
        if (response == null)
        {
            throw new ApiException(
                $"Product with ID {request.Id} was not found.",
                "Not Found",
                404,
                "The requested product does not exist in our database.",
                "PRODUCT_NOT_FOUND"
            );
        }

        await _productRepository.Delete(response);
        return Unit.Value;
    }
}