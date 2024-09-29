using Dapper;
using examOrderSystem.Models.Order;
using examOrderSystem.Models.Order.OrderQueries;
using Npgsql;

namespace examOrderSystem.Services.OrderService;

public class OrderService : IOrderService
{
    public async Task<IEnumerable<Order>> GetOrders()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Order>(SqlCommandOrder.GetOrders);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Order?> GetOrderById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Order>(SqlCommandOrder.GetOrderById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateOrder(Order order)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrder.CreateOrder, order) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrder.UpdateOrder, order) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteOrder(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrder.DeleteOrder, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetOrderByDateAndStatus>> GetOrderByDateAndStatusAsync(DateTime startDate, DateTime endDate,string status)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetOrderByDateAndStatus>(SqlCommands.SelectOrderByDateAndStatus, new { StartDate = @startDate, EndDate = @endDate, Status = @status });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetSalesStatistics>> GetSalesStatisticsAsync(int month, int year)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetSalesStatistics>(SqlCommands.SelectSalesStatistics, new { Month = @month, Year = @year });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetOrderWithCutomerProductOrder>> GetOrderWithCutomerProductOrderAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetOrderWithCutomerProductOrder>(SqlCommands.SelectOrderWithCutomerProduct);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string SelectOrderByDateAndStatus = @"select * from orders
                                                      where orderDate between @StartDate and @EndDate and status = @Status";
    
    public const string SelectSalesStatistics = @"select * from orders
                                                where EXTRACT(MONTH FROM orderDate) = @Month and EXTRACT(YEAR FROM orderDate) = @Year";

    public const string SelectOrderWithCutomerProduct = @"select o.id as orderId, o.orderDate, c.id as customerId, c.fullName as customerName, c.email as customerEmail, p.name as productName, oi.price, oi.quantity from orderitems oi
                                                          join orders o on o.id = oi.orderId
                                                          join customers c on c.id = o.customerId
                                                           join products p on p.id = oi.productId";
}
