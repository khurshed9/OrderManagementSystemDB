namespace examOrderSystem.Models.Customer.CustomerQueries;

public class GetCustomerWithQuantityAmount
{
    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int OrderCount { get; set; }

    public int TotalAmount { get; set; }
    
}