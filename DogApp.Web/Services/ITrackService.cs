using DogApp.Web.Dto;

namespace DogApp.Web.Services;

public interface ITrackService
{
    Task<Root> GetTrackAsync(string? name);
    Task<List<TrackDto>> GetAllTracks();
};
