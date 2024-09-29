namespace examOrderSystem.Models.Product.ProductQueries;

public class GetProductWithTotalSumOfOrder
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int TotalSum { get; set; }
}