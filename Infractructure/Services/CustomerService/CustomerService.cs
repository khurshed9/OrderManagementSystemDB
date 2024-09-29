using Dapper;
using examOrderSystem.Models.Customer;
using examOrderSystem.Models.Customer.CustomerQueries;
using Npgsql;
namespace examOrderSystem.Services.CustomerService;

public class CustomerService : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Customer>(SqlCommandCustomer.GetCustomers);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Customer?> GetCustomerById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Customer>(SqlCommandCustomer.GetCustomerById, new { Id = @id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateCustomer(Customer customer)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCustomer.CreateCustomer, customer) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCustomer(Customer customer)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCustomer.UpdateCustomer, customer) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCustomer(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCustomer.DeleteCustomer, new { Id = @id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

   


        public async Task<IEnumerable<GetCustomerWithOrder?>> GetCustomerWithOrderAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
                {
                    await connection.OpenAsync();
                    return await connection.QueryAsync<GetCustomerWithOrder>(SqlCommand.SelectCustomerWithOrderAsync,
                        new { StartDate = @startDate, EndDate = @endDate });
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<GetCustomerWithQuantityAmount>> GetCustomerWithQuantityAmountAsync()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
                {
                    await connection.OpenAsync();
                    return await connection.QueryAsync<GetCustomerWithQuantityAmount>(SqlCommand.SelectCustomerWithQuantityAmount);
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<GetCustomersWhoDidntOrderLastYear>> GetCustomersWhoDidntOrderLastYearAsync()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
                {
                    await connection.OpenAsync();
                    return await connection.QueryAsync<GetCustomersWhoDidntOrderLastYear>(SqlCommand.SelectCustomersWhoDidntOrderLastYear);
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    
    
}


file class SqlCommand
{
    public const string SelectCustomerWithOrderAsync = @"select c.id as customerId, c.fullName, c.email, c.phone, o.totalAmount, o.orderDate, o.status from orders o
                               join customers c on c.id = o.customerid
                                where o.orderDate between @StartDate and @EndDate
                              ";

    public const string SelectCustomerWithQuantityAmount = @"select c.id as customerId, c.fullName as customerName, Count(o.id) as orderCount,Sum(o.totalAmount) as totalAmount from orders o 
                                                            join customers c on c.id = o.customerId
                                                            group by c.id,c.fullName";
    
    public const string SelectCustomersWhoDidntOrderLastYear = @"select c.id as customerId, c.fullName as customerName, c.email, c.phone,o.orderDate from orders o
                                                                 join customers c on c.id = o.customerId
                                                                 where Extract(year from o.orderDate) <= (Extract(year from current_date) - 1)
                                                                 group by c.id, c.fullName, c.email, c.phone, o.orderDate";
}
