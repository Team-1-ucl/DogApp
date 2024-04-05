namespace DogApp.Web.Dto;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public enum Category { Sign, Extra }
    public Category ItemCategory { get; set; }
    public ICollection<TrackItem> TrackItems { get; set; }

}