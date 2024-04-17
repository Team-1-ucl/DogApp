using DogApp.Web.Dto;
using DogApp.Web.Dto.TrackDtos;

namespace DogApp.Web.Services.Interfaces;

public interface ITrackService
{
    Task<Root> GetTrackAsync(string? name);
    Task<List<TrackDtoOnlyName>> GetAllTracks();

    Task CreateTrackAsync(TrackDtoOnlyName   track);
};
