using DogApp.Web;
using System.Collections.ObjectModel;
using DogApp.Web.Dto.ItemDtos;

namespace DogApp.Web.Dto.TrackDtos
{
    public class TrackDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string? Category { get; set; }
        public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();

        public TrackDto() { }
    }

    public class TrackDtoOnlyName
    {
        public string Name { get; set; }

        public TrackDtoOnlyName(string name) { Name = name; }
    }
   
    public class TrackDtoUserCreate
    {
        public string? Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Category { get; set; }
        
        public TrackDtoUserCreate(string? name, int height, int width, string category)
        {
            Name = name;
            Height = height;
            Width = width;
            Category = category;
        }





    }
}
