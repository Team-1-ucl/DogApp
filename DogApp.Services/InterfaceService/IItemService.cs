using DogApp.Data.EntityModels;

namespace DogApp.Services.InterfaceService
{
    public interface IItemService
    {
        Task CreateItem(Item item);

        Task<List<Item>> GetAllItems();
    }
}