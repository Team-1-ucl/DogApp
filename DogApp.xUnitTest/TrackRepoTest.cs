using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
namespace DogApp.xUnitTest
{
    /// <summary>
    /// Test class for the TrackRepo class.
    /// </summary>
    public class TrackRepoTest
    {
        /// <summary>
        /// The TrackRepo instance being tested.
        /// </summary>
        private readonly TrackRepo _trackRepository;
        /// <summary>
        /// The DataContext instance used for testing.
        /// </summary>
        private readonly DataContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackRepoTest"/> class.
        /// </summary>
        public TrackRepoTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
                 .Options;
            _context = new DataContext(options);
            _trackRepository = new TrackRepo(_context);
        }

        /// <summary>
        /// Represents a test method that creates an item and verifies its creation.
        /// </summary>
        /// <param name="trackName">The name of the track.</param>
        /// <param name="height">The height of the track.</param>
        /// <param name="width">The width of the track.</param>
        /// <param name="category">The category of the track.</param>
        /// <returns>A task that represents the asynchronous test method.</returns>
        [Theory]
        [InlineData("Bane 1", 15, 2, "Open")]
        [InlineData("Bane 2", 1, 55, "Champion")]
        [InlineData("Bane 2", 1, 55, "Begynder")]
        public async Task CreateItem_ShouldCreate(string trackName, int height, int width, string category)
        {
            // Arrange
            var track = new DogApp.Data.EntityModels.Track { Name = trackName, Height = height, Width = width, Category = category };

            // Act
            await _trackRepository.AddAsync(track);
            await _context.SaveChangesAsync();

            try
            {
                // Assert
                track.Should().NotBeNull();
                track.Name.Should().Be(trackName);
                track.Height.Should().BeGreaterThan(0);
                track.Height.Should().BePositive();
                track.Width.Should().BeGreaterThan(0);
                track.Width.Should().BePositive();

                var createdTrack = await _context.Tracks.FirstOrDefaultAsync(t => t.Id == track.Id);
                createdTrack.Should().NotBeNull();
                createdTrack.Name.Should().Be(trackName);
                createdTrack.Height.Should().Be(height);
                createdTrack.Width.Should().Be(width);
                createdTrack.Category.Should().Be(category);
            }
            finally
            {
                // Clean Up
                await _trackRepository.DeleteAsync(track);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Represents a test method that verifies the functionality of retrieving all entities.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        /// <param name="width">The width of the entity.</param>
        /// <param name="category">The category of the entity.</param>
        /// <returns>A task that represents the asynchronous test method.</returns>
        [Theory]
        [InlineData("Bane 1", 15, 2, "Open")]
        [InlineData("Bane 2", 1, 55, "Champion")]
        [InlineData("Bane 3", 4, 63, "Champion")]
        public async Task GetAllAsync_ShouldReturnAllEntities(string name, int height, int width, string category)
        {
            // Arrange
            var tracks = new List<Track>
    {
        new() { Name = name, Height = height, Width = width, Category = category },
        // Add more tracks as needed
    };

            await _context.Tracks.AddRangeAsync(tracks);
            await _context.SaveChangesAsync();

            // Act
            var result = await _trackRepository.GetAllAsync();

            // Assert
            result.Should().NotBeEmpty();

            // Clean up
            foreach (var track in tracks)
            {
                _context.Tracks.Remove(track);
            }
            await _context.SaveChangesAsync(); // Save changes to the database to delete the tracks


        }
        /// <summary>
        /// Represents a test method that verifies the functionality of retrieving an entity by its ID.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        /// <param name="width">The width of the entity.</param>
        /// <param name="category">The category of the entity.</param>
        /// <returns>A task that represents the asynchronous test method.</returns>
        [Theory]
        [InlineData("Bane 1", 15, 2, "Open")]
        [InlineData("Bane 2", 1, 55, "Champion")]
        [InlineData("Bane 3", 4, 63, "Champion")]
        public async Task GetByIdAsync_ShouldReturnCorrectEntity(string name, int height, int width, string category)
        {
            // Arrange
            var track = new Track { Name = name, Height = height, Width = width, Category = category };

            await _trackRepository.AddAsync(track);
            // Retrieve the latest inserted entity from the database
            var latestTrack = await _context.Tracks.OrderByDescending(t => t.Id).FirstOrDefaultAsync();

            // Act
            var result = await _trackRepository.GetByIdAsync(latestTrack.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(latestTrack, options => options.Excluding(e => e.Id));

            // Clean up
            await _trackRepository.DeleteAsync(track);
        }
    }
}