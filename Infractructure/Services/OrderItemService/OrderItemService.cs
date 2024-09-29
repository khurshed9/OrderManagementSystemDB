using Dapper;
using examOrderSystem.Models.OrderItem;
using Npgsql;

namespace examOrderSystem.Services.OrderItemService;

public class OrderItemService : IOrderItemService
{
    public async Task<IEnumerable<OrderItem>> GetOrderItems()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<OrderItem>(SqlCommandOrderItem.GetOrderItems);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<OrderItem?> GetOrderItemById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<OrderItem>(SqlCommandOrderItem.GetOrderItemById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateOrderItem(OrderItem orderItem)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrderItem.CreateOrderItem, orderItem) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateOrderItem(OrderItem orderItem)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrderItem.UpdateOrderItem, orderItem) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteOrderItem(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandOrderItem.DeleteOrderItem, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
