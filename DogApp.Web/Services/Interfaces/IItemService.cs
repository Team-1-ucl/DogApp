using DogApp.Web.Dto.ItemDtos;

namespace DogApp.Web.Services.Interfaces;

public interface IItemService
{
    Task<ItemDto> GetItemAsync(int id);
    Task<List<ItemDto>> GetAllItems();

    Task CreateItemAsync(ItemDtoUserCreate item);
    public string GetImageForItem(string itemName);
}
