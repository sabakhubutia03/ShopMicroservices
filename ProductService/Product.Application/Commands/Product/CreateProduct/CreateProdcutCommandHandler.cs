using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Product.Create;

public class CreateProdcutCommandHandler : IRequestHandler<CreateProductCommand , ProductResponseDto>
{
    private readonly IProductRepository _productRepository;

    public CreateProdcutCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new Domain.Entity.Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId,
            Stock = request.Stock,
            Created = DateTime.UtcNow

        };

        var createProduct = await _productRepository.Create(response);
        if (createProduct == null)
        {
            throw new ApiException(
                "Failed to create product",
                "Bad Request",
                400,
                "Failed to create product",
                "PRODUCT_CREATE_FAILED"
                );
        }

        return new ProductResponseDto
        {
            Id = createProduct.Id,
            Name = createProduct.Name,
            Price = createProduct.Price,
            Stock = createProduct.Stock,
            Created = createProduct.Created,
            CategoryName = createProduct.Category?.Name
        };
    }
}