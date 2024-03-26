using DogApp.Data.EntityModels;

namespace DogApp.Services
{
    public interface ITrackService
    {
        Task CreateTrack(Track track);
    }
}
