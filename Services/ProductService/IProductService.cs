using examOrderSystem.Models.Product;
using examOrderSystem.Models.Product.ProductQueries;

namespace examOrderSystem.Services.ProductService;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    
    Task<Product?> GetProductById(Guid id);
    
    Task<bool> CreateProduct(Product product);
    
    Task<bool> UpdateProduct(Product product);
    
    Task<bool> DeleteProduct(Guid id);

    Task<IEnumerable<GetProductWith0StockQuantity>> GetProductWith0StockQuantityAsync();
    
    Task<IEnumerable<GetProductWithPopularSell>> GetProductWithPopularSellAsync();

    Task<IEnumerable<GetOrderByProduct>> GetOrderByProductAsync(Guid productId);
    
    Task<IEnumerable<GetProductWithTotalSumOfOrder>> GetProductWithTotalSumOfOrderAsync();
}