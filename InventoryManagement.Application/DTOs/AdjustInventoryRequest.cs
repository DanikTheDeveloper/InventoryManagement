namespace InventoryManagement.Application.DTOs;

public class AdjustInventoryRequest
{
    public Guid ProductId { get; set; }
    public Guid WarehouseId { get; set; }
    public int QuantityChange { get; set; }
    public string Reason { get; set; } = string.Empty;
}