namespace examOrderSystem.Models.Product;

public class SqlCommandProduct
{
    public const string GetProducts = "select * from products";
    
    public const string GetProductById = "select * from products where id = @id";
    
    public const string CreateProduct = "insert into products (id,name, price, stockQuantity,createdAt) values (@id,@name, @price, @stockQuantity,@createdAt)";
    
    public const string UpdateProduct = "update products set id = @id, name = @name, price = @price, stockQuantity = @stockQuantity, createdAt = @createdAt where id = @id";
    
    public const string DeleteProduct = "delete from products where id = @id";
}