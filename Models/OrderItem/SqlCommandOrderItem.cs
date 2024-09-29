namespace examOrderSystem.Models.OrderItem;

public class SqlCommandOrderItem
{
    public const string GetOrderItems = "select * from orderItems;";
    
    public const string GetOrderItemById = "select * from orderItems where id = @id;";
    
    public const string CreateOrderItem = 
        "insert into orderItems (id, orderId, productId, quantity, price, createdAt) " +
        "values (@id, @orderId, @productId, @quantity, @price, @createdAt);";
    
    public const string UpdateOrderItem = 
        "update orderItems set id = @id, orderId = @orderId, productId = @productId, " +
        "quantity = @quantity, price = @price, createdAt = @createdAt " +
        "where id = @id;";
    
    public const string DeleteOrderItem = "delete from orderItems where id = @id;";
}
