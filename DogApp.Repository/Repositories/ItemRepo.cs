using DogApp.Data;
using DogApp.Shared.EntityModels;


namespace DogApp.Repository;

public class ItemRepo(DataContext context) : GenericRepository<Item>(context), IItemRepo
{
}
