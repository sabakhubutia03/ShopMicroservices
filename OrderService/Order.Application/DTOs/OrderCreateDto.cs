namespace Order.Application.DTOs;

public class OrderCreateDto
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
}