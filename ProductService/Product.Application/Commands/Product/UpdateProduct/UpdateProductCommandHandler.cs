using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler :IRequestHandler<UpdateProdcutCommand , ProductResponseDto>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> Handle(UpdateProdcutCommand request, CancellationToken cancellationToken)
    {
        var productId = await _productRepository.GetById(request.Id);
        if (productId == null)
        {
            throw new ApiException(
                $"Product with ID {request.Id} was not found.",
                "Not Found",
                404,
                "The requested product does not exist in our database.",
                "PRODUCT_NOT_FOUND"
            );
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            productId.Name =  request.Name;
        }

        if (request.Stock > 0)
        {
            productId.Stock = request.Stock;
        }

        if (request.Price > 0)
        {
            productId.Price = request.Price;
        }

        await _productRepository.Update(productId);

        return new ProductResponseDto
        {
            Id = productId.Id,
            Name = productId.Name,
            Stock = productId.Stock,
            Price = productId.Price,
            Created = productId.Created,
            CategoryName = productId.Category?.Name
        };

    }
}