﻿namespace examOrderSystem.Models.Order;

public class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public int TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}