using DogApp.Web.Dto;
using Newtonsoft.Json;

namespace DogApp.Web.Services;

/// <summary>
/// Service til håndtering af spor.
/// </summary>
/// <param name="httpClient">HttpClientFactory til oprettelse af HttpClient.</param>
public class TrackService : ITrackService
{

    private readonly HttpClient _httpClient;

    public TrackService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TrackDto>> GetAllTracks()
    {

        HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "track/GetAllTracks");

        string responseBody = await response.Content.ReadAsStringAsync();

        List<TrackDto>? tracks = JsonConvert.DeserializeObject<List<TrackDto>>(responseBody);

        return tracks;

    }

    public async Task<Root> GetTrackAsync(string? name)
    {


        HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);
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
