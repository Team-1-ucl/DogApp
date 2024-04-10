using DogApp.Data.EntityModels;

namespace DogApp.Services.InterfaceService
{
    public interface IItemService
    {
        Task CreateItem(Item item);

        Task<List<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task UpdateItemById(Item item);
    }
}