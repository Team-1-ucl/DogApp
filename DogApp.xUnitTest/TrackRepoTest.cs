using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
namespace DogApp.xUnitTest
{

    public class TrackRepoTest
    {
        private readonly TrackRepo _trackRepository;
        private readonly DataContext _context;

        public TrackRepoTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
                 .Options;
            _context = new DataContext(options);
            _trackRepository = new TrackRepo(_context);
        }

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

            await _trackRepository.DeleteAsync(track);
        }
    }
}