namespace Product.Domain.Entity;

public class Product
{
    public int Id { get; set; }
    
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow; 
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}