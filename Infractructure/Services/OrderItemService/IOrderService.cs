using examOrderSystem.Models.OrderItem;

namespace examOrderSystem.Services.OrderItemService;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetOrderItems();
    
    Task<OrderItem?> GetOrderItemById(Guid id);
    
    Task<bool> CreateOrderItem(OrderItem orderItem);
    
    Task<bool> UpdateOrderItem(OrderItem orderItem);
    
    Task<bool> DeleteOrderItem(Guid id);
}
