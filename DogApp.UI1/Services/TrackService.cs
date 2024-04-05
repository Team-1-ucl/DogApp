using DogApp.UI1.Dto;
using Newtonsoft.Json;

namespace DogApp.UI1.Services;

/// <summary>
/// Service til håndtering af spor.
/// </summary>
/// <param name="httpClientFactory">HttpClientFactory til oprettelse af HttpClient.</param>
public class TrackService(IHttpClientFactory httpClientFactory) : ITrackService
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IHttpClientFactory? _httpClientFactory = httpClientFactory;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<TrackDto>> GetAllTracks()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("Track");

        HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/tracks/GetAllTracks");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            List<TrackDto>? tracks = JsonConvert.DeserializeObject<List<TrackDto>>(responseBody);

            return tracks;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<Root> GetTrackAsync(string? name)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("Track");

        HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            Root? track = JsonConvert.DeserializeObject<Root>(responseBody);

            return track;
        }
        else
        {
            return null;
        }

    }


}
