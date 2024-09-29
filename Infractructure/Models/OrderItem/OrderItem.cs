namespace examOrderSystem.Models.OrderItem;

public class OrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public DateTime CreatedAt { get; set; }
}