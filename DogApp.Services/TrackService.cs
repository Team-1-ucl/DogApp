using DogApp.Data.EntityModels;
using DogApp.Repository;

namespace DogApp.Services;
public class TrackService(ITrackRepo trackRepository) : ITrackService
{
    private readonly ITrackRepo _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));

    public async Task CreateTrack(Track track)
    {
        ArgumentNullException.ThrowIfNull(track);
        await _trackRepository.AddAsync(track);
    }

    public async Task<IEnumerable<Track>> GetAllTracksAsync()
    {
        return await _trackRepository.GetAllAsync();
    }
}
