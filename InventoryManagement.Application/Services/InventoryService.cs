using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services;

public class InventoryService
{
	private readonly IInventoryRepository _inventoryRepository;
	private readonly IEventPublisher _eventPublisher;

	public InventoryService(
		IInventoryRepository inventoryRepository,
		IEventPublisher eventPublisher)
	{
		_inventoryRepository = inventoryRepository;
		_eventPublisher = eventPublisher;
	}

	public async Task<List<InventoryItemDto>> GetInventoryAsync()
	{
		var items = await _inventoryRepository.GetAllAsync();

		return items.Select(x => new InventoryItemDto
		{
			Id = x.Id,
			ProductId = x.ProductId,
			WarehouseId = x.WarehouseId,
			QuantityOnHand = x.QuantityOnHand,
			ReorderThreshold = x.ReorderThreshold
		}).ToList();
	}

	public async Task AdjustInventoryAsync(AdjustInventoryRequest request)
	{
		var item = await _inventoryRepository.GetByProductAndWarehouseAsync(
			request.ProductId,
			request.WarehouseId);

		if (item == null)
			throw new InvalidOperationException("Inventory item not found.");

		item.AdjustQuantity(request.QuantityChange);

		var movement = new StockMovement(
			request.ProductId,
			request.WarehouseId,
			request.QuantityChange,
			request.Reason);

		await _inventoryRepository.AddStockMovementAsync(movement);
		await _inventoryRepository.SaveChangesAsync();

		await _eventPublisher.PublishAsync("InventoryAdjusted", new
		{
			request.ProductId,
			request.WarehouseId,
			request.QuantityChange,
			item.QuantityOnHand,
			IsBelowThreshold = item.IsBelowThreshold(),
			OccurredAtUtc = DateTime.UtcNow
		});
	}
}