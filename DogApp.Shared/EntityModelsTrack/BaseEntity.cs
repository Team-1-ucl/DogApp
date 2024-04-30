using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApp.Shared.EntityModelsTrack
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
