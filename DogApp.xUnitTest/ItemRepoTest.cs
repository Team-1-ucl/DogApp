using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
namespace DogAppTest
{
    public class ItemRepositoryTest
    {
        private readonly ItemRepo _itemRepository;
        private readonly DataContext _context;

        public ItemRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
                 .Options;
            _context = new DataContext(options);
            _itemRepository = new ItemRepo(_context);
        }

        [Theory]
        [InlineData("Sign 1", "Start skilt", "image", Item.Category.Sign)]
        [InlineData("Sign 2", "Slut skilt", "image", Item.Category.Sign)]
        [InlineData("Sign 3", "øvelse 3", "image", Item.Category.Sign)]
        public async Task CreateItem_ShouldCreate(string sign, string description, string image, Item.Category itemCategory)
        {
            // arrange
            var item = new Item { Name = sign, Description = description, Image = image, ItemCategory = itemCategory };

            // act
            await _itemRepository.AddAsync(item);
            await _context.SaveChangesAsync();
            // assert
            
            item.Should().NotBeNull();
            item.Name.Should().Contain("Sign");
            item.Description.Should().NotBeNull();
            item.Image.Should().NotBeNull();
            item.ItemCategory.Should().Be(Item.Category.Sign);

            await _itemRepository.DeleteAsync(item);
        }
        [Theory]
        [InlineData("Sign 1", "Description of Sign 1", "Hest", Item.Category.Sign)]
        [InlineData("Sign 2", "Description of Sign 1", "Ko", Item.Category.Sign)]
        [InlineData("Sign 3", "Description of Sign 1", "Delfin", Item.Category.Sign)]
        public async Task UpdateItem_ShouldUpdate(string name, string description, string image, Item.Category category)
        {
            //Arrange
            var item = new Item { Name = name, Description = description, Image = image, ItemCategory = category };
            //Act
            await _itemRepository.AddAsync(item);

            item.Image = "Hund";
            await _itemRepository.UpdateAsync(item);

            item.Image.Should().Be("Hund");

            await _itemRepository.DeleteAsync(item);

        }
    }
}
