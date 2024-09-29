namespace examOrderSystem.Models.Customer;

public class SqlCommandCustomer
{
    public const string GetCustomers = "select * from customers";
    
    public const string GetCustomerById = "select * from customers where id = @id";

    public const string CreateCustomer =
        "insert into customers(id,fullName,email,phone,createdAt) values (@id,@fullName,@email,@phone,@createdAt)";
    
    public const string UpdateCustomer = "update customers set id = @id,fullName = @fullName,email = @email,phone = @phone,createdAt = @createdAt where id = @id";
    
    public const string DeleteCustomer = "delete from customers where id = @id";
}