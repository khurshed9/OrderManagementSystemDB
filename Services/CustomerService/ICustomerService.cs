using examOrderSystem.Models.Customer;
using examOrderSystem.Models.Customer.CustomerQueries;

namespace examOrderSystem.Services.CustomerService;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetCustomers();
    
    Task<Customer?> GetCustomerById(Guid id);
    
    Task<bool> CreateCustomer(Customer customer);
    
    Task<bool> UpdateCustomer(Customer customer);
    
    Task<bool> DeleteCustomer(Guid id);

    Task<IEnumerable<GetCustomerWithOrder?>> GetCustomerWithOrderAsync(DateTime startDate, DateTime endDate);

    Task<IEnumerable<GetCustomerWithQuantityAmount>> GetCustomerWithQuantityAmountAsync();
    
    Task<IEnumerable<GetCustomersWhoDidntOrderLastYear>> GetCustomersWhoDidntOrderLastYearAsync();
}