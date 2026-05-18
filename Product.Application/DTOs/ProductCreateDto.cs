namespace Product.Application.DTOs;

public class ProductCreateDto 
{ 
    
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
} 