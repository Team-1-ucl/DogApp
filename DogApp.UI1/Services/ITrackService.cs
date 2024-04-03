using DogApp.UI1.Dto;

namespace DogApp.UI1.Services
{
    public interface ITrackService
    {
        Task<TrackDto> GetTrackAsync(string? name);
        Task<List<TrackDto>> GetAllTracks();
    };
}
