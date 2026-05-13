using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities;

public class Warehouse
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Code { get; private set; }
    public string Name { get; private set; }

    private Warehouse() { }

    public Warehouse(string code, string name)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Warehouse code is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Warehouse name is required.");

        Code = code;
        Name = name;
    }
}