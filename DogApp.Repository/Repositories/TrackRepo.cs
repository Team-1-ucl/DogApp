using DogApp.Data;
using DogApp.Data.EntityModels;


namespace DogApp.Repository;

public class TrackRepo(DataContext context) : GenericRepository<Track>(context), ITrackRepo
{
}