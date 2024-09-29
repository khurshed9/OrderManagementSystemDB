namespace examOrderSystem.Models.Order;

public class SqlCommandOrder
{
    public const string GetOrders = "select * from orders;";
    
    public const string GetOrderById = "select * from orders where id = @id;";
    
    public const string CreateOrder = 
        "insert into orders (id, customerId, totalAmount, orderDate, status, createdAt) " +
        "values (@id, @customerId, @totalAmount, @orderDate, @status, @createdAt);";
    
    public const string UpdateOrder = 
        "update orders set id = @id, customerId = @customerId, totalAmount = @totalAmount, " +
        "orderDate = @orderDate, status = @status, createdAt = @createdAt " +
        "where id = @id;";
    
    public const string DeleteOrder = "delete from orders where id = @id;";
}