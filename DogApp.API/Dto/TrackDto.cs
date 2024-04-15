using System.Collections.ObjectModel;

namespace DogApp.API.Dto;

public class TrackDtoOnlyName
{
    
    public string? Name { get; set; }
    

    public TrackDtoOnlyName(string name)
    {
        this.Name = name;
    }
}