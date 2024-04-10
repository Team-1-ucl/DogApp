using System.Collections.ObjectModel;

namespace DogApp.Data.EntityModels;

public class Track : BaseEntity
{
    public int? Height { get; set; }
    public int? Width { get; set; }
    public Collection<TrackItem>? TrackItems { get; set; }
    public string? Category { get; set; }
    public Track()
    {

    }
    public Track(string name) : this()
    {
        Name = name;
    }
}
