namespace examOrderSystem.Models.Order.OrderQueries;

public class GetOrderWithCutomerProductOrder
{
    public Guid OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }
}