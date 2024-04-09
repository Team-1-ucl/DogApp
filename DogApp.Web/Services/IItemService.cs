using DogApp.Web.Dto;

namespace DogApp.Web.Services
{
    public interface IItemService
    {
        Task<IItemService> GetItemAsync(string? name);
        Task<List<ItemDto>> GetAllItems();
    }
}
