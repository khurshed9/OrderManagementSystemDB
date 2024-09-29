namespace examOrderSystem.Models.Product.ProductQueries;

public class GetProductWithPopularSell
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }
}