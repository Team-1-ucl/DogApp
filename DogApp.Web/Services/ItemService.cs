using DogApp.Web.Dto;
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
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/GetAllItems");
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ItemDto>? items = JsonConvert.DeserializeObject<List<ItemDto>>(responseBody);

            return items;
        }

        public Task<IItemService> GetItemAsync(string? name)
        {
            throw new NotImplementedException();
        }
    }
}
