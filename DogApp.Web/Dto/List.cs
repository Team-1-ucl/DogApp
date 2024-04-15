using Newtonsoft.Json;

namespace DogApp.Web.Dto;

public class List
{
    [JsonProperty("track")]
    public List<TrackDtoOnlyName> Tracks { get; set; }
}

