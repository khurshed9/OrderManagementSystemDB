namespace examOrderSystem.Models.Product.ProductQueries;

public class GetOrderByProduct
{
    public Guid OrderId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public int StockQuantity { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;
}