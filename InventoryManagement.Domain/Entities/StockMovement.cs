using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities;

public class StockMovement
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ProductId { get; private set; }
    public Guid WarehouseId { get; private set; }

    public int QuantityChange { get; private set; }
    public string Reason { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    private StockMovement() { }

    public StockMovement(Guid productId, Guid warehouseId, int quantityChange, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason is required.");

        ProductId = productId;
        WarehouseId = warehouseId;
        QuantityChange = quantityChange;
        Reason = reason;
    }
}