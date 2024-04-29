using DogApp.Data;
using DogApp.Shared.EntityModels;


namespace DogApp.Repository;

public class TrackRepo(DataContext context) : GenericRepository<Track>(context), ITrackRepo
{
}