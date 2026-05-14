using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public Task<List<InventoryItem>> GetAllAsync()
    {
        return _context.InventoryItems.ToListAsync();
    }

    public Task<InventoryItem?> GetByProductAndWarehouseAsync(Guid productId, Guid warehouseId)
    {
        return _context.InventoryItems
            .FirstOrDefaultAsync(x =>
                x.ProductId == productId &&
                x.WarehouseId == warehouseId);
    }

    public async Task AddStockMovementAsync(StockMovement movement)
    {
        await _context.StockMovements.AddAsync(movement);
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}