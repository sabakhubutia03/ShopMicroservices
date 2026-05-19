using Product.Application.DTOs;

namespace Product.Application.Interface;

public interface IProductService 
{
    Task<ProductResponseDto> CreateProduct (ProductCreateDto productCreateDto); 
    Task<IEnumerable<ProductResponseDto>> GetAllProducts();
    Task<ProductResponseDto> GetProductById(int id);
    Task<ProductResponseDto> UpdateProduct(int id,ProductUpdateDto productUpdateDto);
    Task DeleteProduct(int id);
}
