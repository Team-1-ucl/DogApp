using DogApp.Web.Dto;
using DogApp.Web.Dto.ItemDtos;
using DogApp.Web.Services.Interfaces;
using Newtonsoft.Json;

namespace DogApp.Web.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ItemDto>> GetAllItems()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "Item/GetAllItems");

            string responseBody = await response.Content.ReadAsStringAsync();

            List<ItemDto?> items = JsonConvert.DeserializeObject<List<ItemDto>>(responseBody);

            return items;


        }

        public async Task<ItemDto> GetItemAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "Item/GetItemById/{id}");

            string responseBody = await response.Content.ReadAsStringAsync();

            ItemDto item = JsonConvert.DeserializeObject<ItemDto>(responseBody);

            return item;
        }

        public string GetImageForItem(string itemName)
        {
            if (itemName == null)
            {
                 return "/images/default.png";
            }
            string imageName = itemName.Replace(" ", ""); 

            string imagePath = $"/images/{imageName}.png";
            return imagePath;
        }

        public async Task CreateItemAsync(ItemDtoUserCreate item)
        {
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "Item/CreateItem", content);
            //response.EnsureSuccessStatusCode();
        }

    }
}
