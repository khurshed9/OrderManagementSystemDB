namespace examOrderSystem.Models.Customer.CustomerQueries;

public class GetCustomersWhoDidntOrderLastYear
{
    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime OrderDate{ get; set; }
}