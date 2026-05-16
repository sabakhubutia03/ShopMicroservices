using Product.Application.DTOs;
using Product.Application.Interface;

namespace Product.Application.Service;

public class ProductService : IProductService
{ 
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<ProductResponseDto> CreateProduct(ProductCreateDto productCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductResponseDto>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}