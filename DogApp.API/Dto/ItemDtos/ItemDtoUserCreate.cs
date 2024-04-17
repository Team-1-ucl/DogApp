namespace DogApp.API.Dto.ItemDtos
{
    public class ItemDtoUserCreate
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsSign { get; set; }
        public string? Category { get; set; }

        public ItemDtoUserCreate(string? name, string? description, string? image, bool isSign, string? category)
        {
            Name = name;
            Description = description;
            Image = image;
            IsSign = IsSign;
            Category = category;
        }
    }
}
