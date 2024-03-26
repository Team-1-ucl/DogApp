using DogApp.Data;
using DogApp.Repository;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;


namespace DogAppTest
{
    public class TrackRepoTest
    {
        private TrackRepo _trackRepository;
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
        [InlineData("Bane 1")]
        [InlineData("Bane 2")]

        public async Task CreateItem_ShouldCreate(string trackName)
        {
            // arrange
            var track = new DogApp.Data.EntityModels.Track {Name = trackName, Height = 10 , Width = 10, Category = "Open"};

            // act
            await _trackRepository.AddAsync(track);
            await _context.SaveChangesAsync();

            // assert
            track.Name.Should().Be(trackName);
        }
    }
}
