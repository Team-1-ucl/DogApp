using DogApp.Data;
using DogApp.Data.EntityModels;
using DogApp.Repository;
using DogApp.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using static DogApp.Data.EntityModels.Item;



namespace DogApp.xUnitTest
{
    public class TrackServiceTests
    {
        private readonly DataContext _context;
        private readonly ITrackRepo _trackRepository;
        private readonly TrackService _trackService;
        /// <summary>
        /// Tests for TrackService-klassen.
        /// </summary>
        public TrackServiceTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Web;Trusted_Connection=True;MultipleActiveResultSets=true;")
                .Options;
            _context = new DataContext(options);
            _trackRepository = new TrackRepo(_context);
            _trackService = new TrackService(_trackRepository);
        }
        /// <summary>
        /// Tests the CreateTrack method of TrackService.
        /// </summary>
        /// <param name="trackName">The name of the track.</param>
        /// <param name="height">The height of the track.</param>
        /// <param name="width">The width of the track.</param>
        /// <param name="category">The category of the track.</param>
        /// <returns></returns>
        /// <returns></returns>
        [Theory]
        [InlineData("Bane 1", 15, 2, "Open")]
        [InlineData("Bane 2", 1, 55, "Champion")]
        [InlineData("Bane 2", 1, 55, "Begynder")]
        public async Task CreateTrack_ValidTrack_ShouldAddTrackToRepository(string trackName, int height, int width, string category)
        {
            // Act
            var track = new Track { Name = trackName, Height = height, Width = width, Category = category };
            try
            {
                // Act
                await _trackService.CreateTrack(track);

                // Assert
                var allTracks = await _trackRepository.GetAllAsync();
                allTracks.Should().ContainEquivalentOf(track, options => options.Excluding(t => t.Id));
            }
            finally
            {
                await Task.Delay(100);
                // Cleanup
                if (track != null)
                {
                    await _trackRepository.DeleteAsync(track);
                }
            }
        }

        /// <summary>
        /// Tester om GetAllTracksAsync-metoden returnerer alt.
        /// </summary>
        /// <param name="name">Navnet på Rally banen.</param>
        /// <returns>En task, der repræsenterer udførelsen af testen.</returns>

        [Theory]
        [InlineData("Bane 1")]
        [InlineData("Bane")]
        public async Task GetAllTracksAsync_ShouldReturnAllTracks(string name)
        {
            // Arrange
            var tracks = new List<Track>
                {
                    new() { Name = name },
                    new() { Name = name + "2" },
                    // Add more tracks as needed
                };
            foreach (var track in tracks)
            {
                await _trackRepository.AddAsync(track);
            }

            // Act
            var result = await _trackService.GetAllTracksAsync();

            // Assert
            result.Should().HaveCount(tracks.Count);
            result.Should().BeEquivalentTo(tracks, options => options.Excluding(t => t.Id));
            // Clean up
            foreach (var track in tracks)
            {
                await _trackRepository.DeleteAsync(track);
            }
        }
        
    }
}

