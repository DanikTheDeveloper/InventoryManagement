using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces;

public interface IInventoryRepository
{
    Task<List<InventoryItem>> GetAllAsync();
    Task<InventoryItem?> GetByProductAndWarehouseAsync(Guid productId, Guid warehouseId);
    Task AddStockMovementAsync(StockMovement movement);
    Task SaveChangesAsync();
}