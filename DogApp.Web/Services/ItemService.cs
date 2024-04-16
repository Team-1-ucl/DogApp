using DogApp.Web.Dto;
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

        public Task<ItemDto> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }
        public string GetImageForItem(string itemName)
        {
            string imageName = itemName.Replace(" ", ""); // Remove spaces from item name

            string imagePath = $"/images/{imageName}.png"; // Assuming image filenames follow the format "{ItemName}.png"

            return imagePath;
        }

        public async Task CreateItemAsync(ItemDto item)
        {
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "Item/CreateItem", content);
            //response.EnsureSuccessStatusCode();
        }

    }
}
