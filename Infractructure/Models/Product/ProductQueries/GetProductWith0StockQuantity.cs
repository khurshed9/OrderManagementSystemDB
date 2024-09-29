namespace examOrderSystem.Models.Product.ProductQueries;

public class GetProductWith0StockQuantity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int StockQuantity { get; set; }

    public DateTime CreatedAt { get; set; }
}