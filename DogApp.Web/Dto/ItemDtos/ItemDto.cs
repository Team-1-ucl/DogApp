using DogApp.Web.Dto.TrackDtos;

namespace DogApp.Web.Dto.ItemDtos;

public class ItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public bool? isSign { get; set; }
    public string? Category { get; set; }
    public ICollection<TrackItem>? TrackItems { get; set; }

}