namespace DogApp.Web.Dto;

public class TrackItem
{
    public int Id { get; set; }

    public ItemDto? Item;
    public int Itemid { get; set; }

    public TrackDto? Track;
    public int Trackid { get; set; }

    public float X { get; set; }
    public float Y { get; set; }

    public int Order { get; set; }
}
