using DogApp.UI1.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace DogApp.UI1.Services
{
    public class TrackService (IHttpClientFactory httpClientFactory) : ITrackService
    {
        
        private readonly IHttpClientFactory? _httpClientFactory;

        public Task<List<TrackDto>> GetAllTracks()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("Track");

            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                TrackDto? track = JsonConvert.DeserializeObject<TrackDto>(responseBody);

                return List<track>;
            }
            else
            {
                return null;
            }
        }

        public async Task<TrackDto?> GetTrackAsync(string? name)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("Track");

            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                TrackDto? track = JsonConvert.DeserializeObject<TrackDto>(responseBody);

                return track;
            }
            else
            {
                return null;
            }
            
        }

       
    }
}
