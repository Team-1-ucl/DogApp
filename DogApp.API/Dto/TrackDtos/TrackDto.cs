using System.Collections.ObjectModel;

namespace DogApp.API.Dto.TrackDtos
{
    public class TrackDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string? Category { get; set; }
        public ICollection<TrackItem>? TrackItems { get; set; }
    }
    public class TrackDtoOnlyName
    {
        public string Name { get; set; }

        public TrackDtoOnlyName(string name) { Name = name; }
    }
    public class TrackDtoUserCreate
    {
        public string? Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Category { get; set; }

        

        public TrackDtoUserCreate(string? name, int height, int width, string category)
        {
            Name = name;
            Height = height;
            Width = width;
            Category = category;
        }
    }
    public class TrackDtoTrackBuilder
    {
        public string? Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Category { get; set; }
        public ICollection<TrackItem>? TrackItems { get; set; }

        public TrackDtoTrackBuilder(string? name, int height, int width, string category, List<TrackItem> items)
        {
            Name = name;
            Height = height;
            Width = width;
            Category = category;
            TrackItems = new List<TrackItem>();
        }
    }
}
