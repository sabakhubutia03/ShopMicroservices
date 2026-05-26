namespace Order.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow; 
}