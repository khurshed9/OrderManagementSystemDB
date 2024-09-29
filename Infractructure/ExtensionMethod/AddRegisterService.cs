using examOrderSystem.Models.Customer.CustomerQueries;
using examOrderSystem.Services.CustomerService;
using examOrderSystem.Services.OrderItemService;
using examOrderSystem.Services.OrderService;
using examOrderSystem.Services.ProductService;

namespace examOrderSystem.ExtensionMethod;

public static class AddRegisterService
{
    public static void AddService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICustomerService, CustomerService>();
        serviceCollection.AddTransient<IOrderService, OrderService>();
        serviceCollection.AddTransient<IOrderItemService, OrderItemService>();
        serviceCollection.AddTransient<IProductService, ProductService>();
    }
}