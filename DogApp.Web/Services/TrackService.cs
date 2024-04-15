using DogApp.Web.Dto;
using DogApp.Web.Services.Interfaces;
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

    public async Task<List<TrackDtoOnlyName>> GetAllTracks()
    {

        HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "track/GetAllTracks");

        string responseBody = await response.Content.ReadAsStringAsync();

        List<TrackDtoOnlyName >? tracks = JsonConvert.DeserializeObject<List<TrackDtoOnlyName>>(responseBody);

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

    public async Task CreateTrackAsync(TrackDtoOnlyName trackDto)
    {
        string json = JsonConvert.SerializeObject(trackDto);
        HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "Track/CreateTrack", content);
        //response.EnsureSuccessStatusCode();
    }


}
