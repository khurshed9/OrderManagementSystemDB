CREATE TABLE customers (
                           id UUID PRIMARY KEY,
                           fullName VARCHAR(255) UNIQUE NOT NULL,
                           email VARCHAR(255) UNIQUE NOT NULL,
                           phone VARCHAR(20),
                           createdAt TIMESTAMP WITH TIME ZONE
);

CREATE TABLE products (
                          id UUID PRIMARY KEY,
                          name VARCHAR(255) UNIQUE NOT NULL,
                          price INT NOT NULL,
                          stockQuantity INT NOT NULL,
                          createdAt TIMESTAMP WITH TIME ZONE
);

CREATE TABLE orders (
                        id UUID PRIMARY KEY,
                        customerId UUID REFERENCES customers(id) ON DELETE CASCADE,
                        totalAmount INT NOT NULL,
                        orderDate TIMESTAMP WITH TIME ZONE,
                        status VARCHAR(50) CHECK (Status IN ('Pending', 'Completed', 'Cancelled')) NOT NULL,
                        createdAt TIMESTAMP WITH TIME ZONE
);

CREATE TABLE orderItems (
                            id UUID PRIMARY KEY,
                            orderId UUID REFERENCES orders(id) ON DELETE CASCADE,
                            productId UUID REFERENCES products(id) ON DELETE CASCADE,
                            quantity INT NOT NULL,
                            price INT NOT NULL,
                            createdAt TIMESTAMP WITH TIME ZONE
);