using examOrderSystem.ExtensionMethod;
using examOrderSystem.Models.Customer;
using examOrderSystem.Models.Order;
using examOrderSystem.Models.OrderItem;
using examOrderSystem.Models.Product;
using examOrderSystem.Services.CustomerService;
using examOrderSystem.Services.OrderItemService;
using examOrderSystem.Services.OrderService;
using examOrderSystem.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:2008");

builder.WebHost.ConfigureKestrel(options => { options.AllowSynchronousIO = true; });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

///////////////////////////////////////////Customer////////////////////////////////


app.MapGet("/api/customers", async ([FromServices] ICustomerService customerService) =>
{
    return await customerService.GetCustomers();
});

app.MapGet("/api/customers/{id}", async ( [FromServices] ICustomerService customerService,Guid id) =>
{
    return await customerService.GetCustomerById(id);
});

app.MapPost("/api/customers", async ( [FromServices] ICustomerService customerService, Customer customer) =>
{
    await customerService.CreateCustomer(customer);
});

app.MapPut("/api/customers/{id}", async ( [FromServices] ICustomerService customerService, Customer customer) =>
{
    await customerService.UpdateCustomer(customer);
});

app.MapDelete("/api/customers/{id}", async ( [FromServices] ICustomerService customerService, Guid id) =>
{
    await customerService.DeleteCustomer(id);
});



///////////////////////////////////////////Order///////////////////////////////


app.MapGet("/api/orders", async ([FromServices] IOrderService orderService) =>
{
    return await orderService.GetOrders();
});

app.MapGet("/api/orders/{id}", async ( [FromServices] IOrderService orderService, Guid id) =>
{
    return await orderService.GetOrderById(id);
});

app.MapPost("/api/orders", async ( [FromServices] IOrderService orderService, Order order) =>
{
    await orderService.CreateOrder(order);
});

app.MapPut("/api/orders/{id}", async ( [FromServices] IOrderService orderService, Order order) =>
{
    await orderService.UpdateOrder(order);
});

app.MapDelete("/api/orders/{id}", async ( [FromServices] IOrderService orderService, Guid id) =>
{
    await orderService.DeleteOrder(id);
});


///////////////////////////////////////////Product////////////////////////////////



app.MapGet("/api/products", async ([FromServices] IProductService productService) =>
{
    return await productService.GetProducts();
});

app.MapGet("/api/products/{id}", async ( [FromServices] IProductService productService, Guid id) =>
{
    return await productService.GetProductById(id);
});

app.MapPost("/api/products", async ( [FromServices] IProductService productService, Product product) =>
{
    await productService.CreateProduct(product);
});

app.MapPut("/api/products/{id}", async ( [FromServices] IProductService productService, Product product) =>
{
    await productService.UpdateProduct(product);
});

app.MapDelete("/api/products/{id}", async ( [FromServices] IProductService productService, Guid id) =>
{
    await productService.DeleteProduct(id);
});



//////////////////////////////////////////OrderItem///////////////////////////////////


app.MapGet("/api/orderItems", async ([FromServices] IOrderItemService orderItemService) =>
{
    return await orderItemService.GetOrderItems();
});

app.MapGet("/api/orderItems/{id}", async ( [FromServices] IOrderItemService orderItemService, Guid id) =>
{
    return await orderItemService.GetOrderItemById(id);
});

app.MapPost("/api/orderItems", async ( [FromServices] IOrderItemService orderItemService, OrderItem orderItem) =>
{
    await orderItemService.CreateOrderItem(orderItem);
});

app.MapPut("/api/orderItems/{id}", async ( [FromServices] IOrderItemService orderItemService, OrderItem orderItem) =>
{
    await orderItemService.UpdateOrderItem(orderItem);
});

app.MapDelete("/api/orderItems/{id}", async ( [FromServices] IOrderItemService orderItemService, Guid id) =>
{
    await orderItemService.DeleteOrderItem(id);
});



//////////////////////////////////////////CustomerWithOrder///////////////////////////////////1


app.MapGet("/api/customers/orders", async (ICustomerService getcustomerWithOrderService,[FromQuery]DateTime startDate,[FromQuery]DateTime endDate) =>
{
    return await getcustomerWithOrderService.GetCustomerWithOrderAsync(startDate, endDate);
});

//////////////////////////////////////////Get products with 0 stockQuantity////////////////////////////////2



app.MapGet("/api/products/out-of-stock", async ([FromServices] IProductService getProductsWithZeroStockQuantityService) =>
{
    return await getProductsWithZeroStockQuantityService.GetProductWith0StockQuantityAsync();
});


///////////////////////////////////////Get customers with quantity and amount///////////////////////////////3


app.MapGet("/api/customers/statistics", async ([FromServices] ICustomerService getCustomersWithQuantityAndAmountService) =>
{
    return await getCustomersWithQuantityAndAmountService.GetCustomerWithQuantityAmountAsync();
});


///////////////////////////////////////////Get orders with customer product order////////////////////////////////////////4



app.MapGet("/api/orders/details", async (IOrderService orderService) =>
{
    return await orderService.GetOrderWithCutomerProductOrderAsync();
});


///////////////////////////////////////////Get orders by start, end date and status////////////////////////////////////////5


app.MapGet("/api/orders/kh/", async ( [FromServices] IOrderService getOrdersByDateAndStatusService,[FromQuery]DateTime startDate,[FromQuery]DateTime endDate,[FromQuery]string status) =>
{
    return await getOrdersByDateAndStatusService.GetOrderByDateAndStatusAsync(startDate, endDate, status);
});


///////////////////////////////////////////Get product with hight sell////////////////////////////////////////6


app.MapGet("/api/products/popular", async ([FromServices] IProductService getProductWithHightSellService) =>
{
    return await getProductWithHightSellService.GetProductWithPopularSellAsync();
});


///////////////////////////////////////////////Get sales statistics///////////////////////////////////////7


app.MapGet("/api/orders/sales-statistics", async ([FromServices] IOrderService getSalesStatisticsService,int month,int year) =>
{
    return await getSalesStatisticsService.GetSalesStatisticsAsync(month,year);
});



////////////////////////////////////////////Get customers who didin't ordered during last year////////////////////////////////8


app.MapGet("/api/customers/inactive", async ([FromServices] ICustomerService getCustomersWhoDidNotOrderService) =>
{
    return await getCustomersWhoDidNotOrderService.GetCustomersWhoDidntOrderLastYearAsync();
});


///////////////////////////////////////////////Get orders by product id////////////////////////////////////////9


app.MapGet("/api/product", async ( [FromServices] IProductService getOrdersByProductIdService,[FromQuery]Guid productId) =>
{
    return await getOrdersByProductIdService.GetOrderByProductAsync(productId);
});


////////////////////////////////////////////Get product with total sum of order////////////////////////////////10



app.MapGet("/api/orders/products-summary", async ([FromServices] IProductService getProductWithTotalSumOfOrderService) =>
{
    return await getProductWithTotalSumOfOrderService.GetProductWithTotalSumOfOrderAsync();
});



app.Run();


