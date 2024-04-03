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

        public async Task<List<TrackDto>> GetAllTracks()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("Track");

            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/tracks/GetAllTracks");
            
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<TrackDto> tracks = JsonConvert.DeserializeObject<List<TrackDto>>(responseBody);

                return tracks;
            }
            else
            {
                return null;
            }
        }

        public async Task<Root> GetTrackAsync(string? name)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("Track");

            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Root track = JsonConvert.DeserializeObject<Root>(responseBody);

                return track;
            }
            else
            {
                return null;
            }
            
        }

       
    }
}
