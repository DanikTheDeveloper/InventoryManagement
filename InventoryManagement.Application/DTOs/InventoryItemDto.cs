namespace InventoryManagement.Application.DTOs;

public class InventoryItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid WarehouseId { get; set; }
    public int QuantityOnHand { get; set; }
    public int ReorderThreshold { get; set; }
}