using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace DogApp.Web.Dto;



public class TrackDtoOnlyName 
{
    public string? Name { get; set; }
    public TrackDtoOnlyName(string? name)
    {
        Name = name;
    }

    

    

}