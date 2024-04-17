using DogApp.Data.EntityModels;
using DogApp.Repository;
using DogApp.Services.Interfaces;


namespace DogApp.Services;

public class ItemService(IItemRepo itemRepo) : IItemService
{
    private readonly IItemRepo _itemrepo = itemRepo ?? throw new ArgumentNullException(nameof(itemRepo));
    public async Task CreateItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        await _itemrepo.AddAsync(item);
    }

    public async Task<List<Item>> GetAllItems()
    {
        return await _itemrepo.GetAllAsync();
    }
    public async Task<Item?> GetItemById(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        return await _itemrepo.GetByIdAsync(id);
    }

    public async Task UpdateItemById(Item item)
    {
        // Get the item to update from the repository
        var itemToUpdate = await _itemrepo.GetByIdAsync(item.Id);

        // Check if the item to update exists
        if (itemToUpdate != null)
        {
            itemToUpdate.Name = item.Name; 

            await _itemrepo.UpdateAsync(itemToUpdate);
        }
        else
        {
            throw new ArgumentException("Item not found.");
        }
    }
    public async Task CreateItemAsync(Item item)
    {
        await _itemrepo.AddAsync(item);
    }

}
