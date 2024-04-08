using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
namespace DogAppTest;
/// <summary>
/// Represents a test class for the ItemRepo class.
/// </summary>
public class ItemRepositoryTest
{
    /// <summary>
    /// The ItemRepo instance being tested.
    /// </summary>
    private readonly ItemRepo _itemRepository;

    /// <summary>
    /// The DataContext instance used for testing.
    /// </summary>
    private readonly DataContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemRepositoryTest"/> class.
    /// </summary>
    public ItemRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
             .Options;
        _context = new DataContext(options);
        _itemRepository = new ItemRepo(_context);
    }
    /// <summary>
    /// Represents a test method that verifies the functionality of creating an item.
    /// </summary>
    /// <param name="sign">The sign of the item.</param>
    /// <param name="description">The description of the item.</param>
    /// <param name="image">The image of the item.</param>
    /// <param name="itemCategory">The category of the item.</param>
    /// <returns>A task that represents the asynchronous test method.</returns>
    [Theory]
    [InlineData("Sign 1", "Start skilt", "image", Item.Category.Sign)]
    [InlineData("Sign 2", "Slut skilt", "image", Item.Category.Sign)]
    [InlineData("Sign 3", "øvelse 3", "image", Item.Category.Sign)]
    public async Task CreateItem_ShouldCreate(string sign, string description, string image, Item.Category itemCategory)
    {
        // Arrange
        var item = new Item { Name = sign, Description = description, Image = image, ItemCategory = itemCategory };

        // Act
        await _itemRepository.AddAsync(item);
        await _context.SaveChangesAsync();

        // Assert
        item.Should().NotBeNull();
        item.Name.Should().Contain("Sign");
        item.Description.Should().NotBeNull();
        item.Image.Should().NotBeNull();
        item.ItemCategory.Should().Be(Item.Category.Sign);

        //Clean Up
        await _itemRepository.DeleteAsync(item);
    }

    /// <summary>
    /// Represents a test method that verifies the functionality of updating an item.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="description">The description of the item.</param>
    /// <param name="image">The image of the item.</param>
    /// <param name="category">The category of the item.</param>
    /// <returns>A task that represents the asynchronous test method.</returns>
    [Theory]
    [InlineData("Sign 1", "Description of Sign 1", "Hest", Item.Category.Sign)]
    [InlineData("Sign 2", "Description of Sign 1", "Ko", Item.Category.Sign)]
    [InlineData("Sign 3", "Description of Sign 1", "Delfin", Item.Category.Sign)]
    public async Task UpdateItem_ShouldUpdate(string name, string description, string image, Item.Category category)
    {
        //Arrange
        var testItem = new Item { Name = name, Description = description, Image = image, ItemCategory = category };

        //Act
        await _itemRepository.AddAsync(testItem);
        testItem.Image = "Hund";
        await _itemRepository.UpdateAsync(testItem);

        //Assert
        testItem.Image.Should().Be("Hund");

        //Clean Up
        await _itemRepository.DeleteAsync(testItem);

    }
}
