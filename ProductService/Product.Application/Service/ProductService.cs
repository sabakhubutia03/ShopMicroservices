using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Service;

public class ProductService : IProductService
{ 
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> CreateProduct(ProductCreateDto productCreateDto)
    {
        var response = new Domain.Entity.Product
        {
            Name = productCreateDto.Name,
            Price = productCreateDto.Price,
            CategoryId = productCreateDto.CategoryId,
            Stock = productCreateDto.Stock,
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
    
    public async Task<IEnumerable<ProductResponseDto>> GetAllProducts()
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
        });
    }

    public async Task<ProductResponseDto> GetProductById(int id)
    {
        var response = await _productRepository.GetById(id);
        if (response == null)
        {
            throw new ApiException(
                $"Product with ID {id} was not found.",
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

    public async Task<ProductResponseDto> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        var product =  await _productRepository.GetById(id);
        if (product == null)
        {
            throw new ApiException(
                $"Product with ID {id} was not found.",
                "Not Found",
                404,
                "The requested product does not exist in our database.",
                "PRODUCT_NOT_FOUND"
            );
        }

        if (!string.IsNullOrWhiteSpace(productUpdateDto.Name))
        {
           product.Name = productUpdateDto.Name;
        }

        if (productUpdateDto.Price != null)
        {
            product.Price = productUpdateDto.Price.Value;
        }

        if (productUpdateDto.CategoryId != null)
        {
            product.CategoryId = productUpdateDto.CategoryId.Value;
        }

        if (productUpdateDto.Stock != null)
        {
            product.Stock = productUpdateDto.Stock.Value;
        }
        
        await _productRepository.Update(product);
        
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Created = product.Created,
            CategoryName = product.Category?.Name
        };
    }

    public async Task DeleteProduct(int id)
    {
        var response = await _productRepository.GetById(id);
        if (response == null)
        {
            throw new ApiException(
                $"Product with ID {id} was not found.",
                "Not Found",
                404,
                "The requested product does not exist in our database.",
                "PRODUCT_NOT_FOUND"
            );
        }
        await _productRepository.Delete(response);
    }
}