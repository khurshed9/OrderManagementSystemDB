namespace examOrderSystem.Models.Customer.CustomerQueries;

public class GetCustomerWithOrder
{
    public Guid CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;
}