using Newtonsoft.Json;

namespace DogApp.Web.Dto;

public class List
{
    [JsonProperty("track")]
    public List<TrackDto> Tracks { get; set; }
}

