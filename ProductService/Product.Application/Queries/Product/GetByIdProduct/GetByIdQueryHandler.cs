using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Queries.Product.GetByIdProduct;

public class GetByIdQueryHandler : IRequestHandler<GetByIdProductQuery , ProductResponseDto>
{
    private readonly IProductRepository _productRepository;

    public GetByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
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

        return new ProductResponseDto
        {
            Id = response.Id,
            Name = response.Name,
            Price = response.Price,
            Stock = response.Stock,
            Created = response.Created,
            CategoryName = response.Category?.Name
        };
    }
}