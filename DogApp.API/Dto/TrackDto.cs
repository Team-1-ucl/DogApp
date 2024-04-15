using System.Collections.ObjectModel;

namespace DogApp.API.Dto;

public class TrackDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int height { get; set; }
    public int width { get; set; }
    public Collection<TrackItem> trackItems { get; set; }
    public string Category { get; set; }

    public TrackDto(string name)
    {
        this.Name = name;
        this.height = 0;
    }
}
