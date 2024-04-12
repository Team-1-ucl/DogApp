using DogApp.Web.Dto;

namespace DogApp.Web.Services.Interfaces;

public interface IItemService
{
    Task<ItemDto> GetItemAsync(int id);
    Task<List<ItemDto>> GetAllItems();
}
