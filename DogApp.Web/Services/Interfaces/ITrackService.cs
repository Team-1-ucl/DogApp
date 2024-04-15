using DogApp.Web.Dto;

namespace DogApp.Web.Services.Interfaces;

public interface ITrackService
{
    Task<Root> GetTrackAsync(string? name);
    Task<List<TrackDtoOnlyName>> GetAllTracks();

    Task CreateTrackAsync(TrackDtoOnlyName   track);
};
