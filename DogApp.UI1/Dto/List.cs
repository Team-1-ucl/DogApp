using Newtonsoft.Json;

namespace DogApp.UI1.Dto
{
    public class List
    {
        [JsonProperty("track")]
        public List<TrackDto> Tracks { get; set; }
    }
}
