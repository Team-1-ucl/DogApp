namespace DogApp.API.Dto.TrackDtos
{
    public class TrackDto
    {
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
}
