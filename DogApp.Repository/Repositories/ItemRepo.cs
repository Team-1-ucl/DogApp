using DogApp.Data;
using DogApp.Data.EntityModels;


namespace DogApp.Repository;

public class ItemRepo(DataContext context) : GenericRepository<Item>(context), IItemRepo
{
}
