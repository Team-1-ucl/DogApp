using DogApp.Shared.EntityModels;

namespace DogApp.Services.Interfaces;

public interface IItemService
{
    Task CreateItem(Item item);

    Task<List<Item>> GetAllItems();
    Task<Item> GetItemById(int id);
    Task UpdateItemById(Item item);
    Task CreateItemAsync(Item item);
}