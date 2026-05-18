namespace Product.Application.DTOs;

public class ProductUpdateDto
{
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public int? CategoryId { get; set; }
    public int? Stock { get; set; }
}