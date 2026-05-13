using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities;

public class InventoryItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ProductId { get; private set; }
    public Guid WarehouseId { get; private set; }

    public int QuantityOnHand { get; private set; }
    public int ReorderThreshold { get; private set; }

    private InventoryItem() { }

    public InventoryItem(Guid productId, Guid warehouseId, int quantityOnHand, int reorderThreshold)
    {
        if (quantityOnHand < 0)
            throw new ArgumentException("Quantity cannot be negative.");

        if (reorderThreshold < 0)
            throw new ArgumentException("Reorder threshold cannot be negative.");

        ProductId = productId;
        WarehouseId = warehouseId;
        QuantityOnHand = quantityOnHand;
        ReorderThreshold = reorderThreshold;
    }

    public void AdjustQuantity(int quantityChange)
    {
        int newQuantity = QuantityOnHand + quantityChange;

        if (newQuantity < 0)
            throw new InvalidOperationException("Inventory quantity cannot go below zero.");

        QuantityOnHand = newQuantity;
    }

    public bool IsBelowThreshold()
    {
        return QuantityOnHand <= ReorderThreshold;
    }
}