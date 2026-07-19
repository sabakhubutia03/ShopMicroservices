using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;

namespace Product.Application.Queries.Product.GetAllProdcut;

public class GetAllProcutQueryHandler : IRequestHandler<GetAllProdcutQuery , List<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProcutQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductResponseDto>> Handle(GetAllProdcutQuery request, CancellationToken cancellationToken)
    {
        var response = await _productRepository.GetAll();
        return response.Select(p => new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Created = p.Created,
            CategoryName = p.Category?.Name
        }).ToList();
    }
}