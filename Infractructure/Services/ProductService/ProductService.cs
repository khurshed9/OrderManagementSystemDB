using Dapper;
using examOrderSystem.Models.Product;
using examOrderSystem.Models.Product.ProductQueries;
using Npgsql;

namespace examOrderSystem.Services.ProductService;

public class ProductService : IProductService
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Product>(SqlCommandProduct.GetProducts);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Product>(SqlCommandProduct.GetProductById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateProduct(Product product)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandProduct.CreateProduct, product) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandProduct.UpdateProduct, product) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandProduct.DeleteProduct, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetProductWith0StockQuantity>> GetProductWith0StockQuantityAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetProductWith0StockQuantity>(SqlCommands.SelectProductWith0StockQuantity);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }


    public async Task<IEnumerable<GetProductWithPopularSell>> GetProductWithPopularSellAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetProductWithPopularSell>(SqlCommands.SelectProductWithPopularSell);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetOrderByProduct>> GetOrderByProductAsync(Guid productId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetOrderByProduct>(SqlCommands.SelectOrderByProduct, new { ProductId = @productId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetProductWithTotalSumOfOrder>> GetProductWithTotalSumOfOrderAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDB.ConnectionF.ConnectionC))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetProductWithTotalSumOfOrder>(SqlCommands.SelectProductWithTotalSumOfOrder);
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
    public const string SelectProductWith0StockQuantity = "select * from products where stockQuantity = 0";
    
    public const string SelectProductWithPopularSell = @"select p.id, p.name, Sum(oi.quantity) as Quantity from orderitems oi
                                                        join products p on p.id = oi.productId
                                                        group by p.id,p.name";

    public const string SelectOrderByProduct = @"select o.id as orderId, p.name as productName,p.price as productPrice,p.stockquantity, o.orderDate, o.status as orderStatus from orders o
                                                join orderitems oi on o.id = oi.orderId
                                                join products p on p.id = oi.productId
                                                where p.id = @productId";
    
    public const string SelectProductWithTotalSumOfOrder = @"select p.id as productId, p.name as productName, Sum(oi.quantity * oi.price) as totalSum from orderitems oi
                                                             join products p on p.id = oi.productId
                                                             group by p.id, p.name";
}
