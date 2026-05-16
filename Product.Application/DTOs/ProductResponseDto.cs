namespace Product.Application.DTOs;

public class ProductResponseDto
{
    public int Id { get; set; } 
    
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
    public DateTime Created { get; set; }   
    public string? CategoryName { get; set; }
}