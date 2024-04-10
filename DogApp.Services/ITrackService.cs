using DogApp.Data.EntityModels;

namespace DogApp.Services;

/// <summary>
/// Interface til tjenesten til håndtering af baner.
/// </summary>
public interface ITrackService
{
    /// <summary>
    /// Opretter en ny bane.
    /// </summary>
    /// <param name="track">Baneobjektet, der skal oprettes.</param>
    /// <returns>En <see cref="Task"/>, der repræsenterer asynkron udførelse af oprettelsen.</returns>
    Task CreateTrack(Track track);
    /// <summary>
    /// Henter alle baner asynkront.
    /// </summary>
    /// <returns>En <see cref="Task{TResult}"/> der indeholder en samling af baner.</returns>
    Task<IEnumerable<Track>> GetAllTracksAsync();

    Task <Track> GetTrackById(int id);
}
