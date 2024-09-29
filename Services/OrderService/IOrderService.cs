using examOrderSystem.Models.Order;
using examOrderSystem.Models.Order.OrderQueries;

namespace examOrderSystem.Services.OrderService;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders();
    
    Task<Order?> GetOrderById(Guid id);
    
    Task<bool> CreateOrder(Order order);
    
    Task<bool> UpdateOrder(Order order);
    
    Task<bool> DeleteOrder(Guid id);

    Task<IEnumerable<GetOrderByDateAndStatus>> GetOrderByDateAndStatusAsync(DateTime startDate, DateTime endDate,string status);

    Task<IEnumerable<GetSalesStatistics>> GetSalesStatisticsAsync(int month,int year);
    
    Task<IEnumerable<GetOrderWithCutomerProductOrder>> GetOrderWithCutomerProductOrderAsync();
}

