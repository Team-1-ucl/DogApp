using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace DogAppTest
{
    public class ItemRepositoryTest
    {
        private ItemRepo _itemRepository;
        private readonly DataContext _context;

        public ItemRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
                 .Options;
            _context = new DataContext(options);
            _itemRepository = new ItemRepo(_context);
        }

        [Fact]
        public async Task CreateItem_ShouldCreate()
        {
            // arrange
            var item = new Item { Name = "Sign 1", Description = "Description of Sign 1", Image = "hest", ItemCategory = Item.Category.Sign };

            // act
            await _itemRepository.AddAsync(item);
            await _context.SaveChangesAsync();
            // assert
           
        }
        [Fact]
        public async Task UpdateItem_ShouldUpdate()
        {
            var item = new Item { Name = "Sign 1", Description = "Description of Sign 1", Image = "hest", ItemCategory = Item.Category.Sign };

            await _itemRepository.AddAsync(item);

            item.Image = "hund";
            await _itemRepository.UpdateAsync(item);

        }
    }
}
