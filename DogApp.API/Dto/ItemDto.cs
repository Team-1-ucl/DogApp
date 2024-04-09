namespace DogApp.API.Dto
{
    public class ItemDto
    {
        public ItemDto(int id, string? name, string? description, string? image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public enum Category { Sign, Extra }
        public Category ItemCategory { get; set; }
        public ICollection<TrackItem> TrackItems { get; set; }

    }
}