using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Sku { get; private set; }
    public string Name { get; private set; }

    private Product() { }

    public Product(string sku, string name)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");

        Sku = sku;
        Name = name;
    }
}