using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogApp.Shared.EntityModelsTrack;

namespace DogApp.Shared.EntityModels
{
    public class Track : BaseEntity
    {
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string? Category { get; set; }
        public ICollection<TrackItem>? TrackItems { get; set; }
        public Track()
        {

        }
        public Track(string name) : this()
        {
            Name = name;
        }
    }
}
