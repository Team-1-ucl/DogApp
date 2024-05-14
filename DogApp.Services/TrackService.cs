using DogApp.Shared.EntityModels;
using DogApp.Repository;
using DogApp.Services.Interfaces;

namespace DogApp.Services;
/// <summary>
/// Service til håndtering af baner.
/// </summary>
/// <param name="trackRepository">Repositoriet til banedata.</param>
public class TrackService(ITrackRepo trackRepository) : ITrackService
{

    /// <summary>
    /// Initialiserer en ny instans af <see cref="ITrackRepo"/>-klassen.
    /// </summary>
    private readonly ITrackRepo _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));

    /// <summary>
    /// Opretter en ny bane.
    /// </summary>
    /// <param name="track">Baneobjektet, der skal oprettes.</param>
    /// <returns>En <see cref="Task"/>, der repræsenterer asynkron udførelse af oprettelsen.</returns>
    public async Task CreateTrack(Track track)
    {
        ArgumentNullException.ThrowIfNull(track);
        await _trackRepository.AddAsync(track);
    }
    /// <summary>
    /// Henter alle baner asynkront.
    /// </summary>
    /// <returns>En <see cref="Task{TResult}"/> der indeholder en samling af baner.</returns>
    public async Task<IEnumerable<Track>> GetAllTracksAsync()
    {
        return await _trackRepository.GetAllAsync();
    }

    public async Task<Track> GetTrackById(int id)
    {
        return await _trackRepository.GetByIdAsync(id);
    }
}

