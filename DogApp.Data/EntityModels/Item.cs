namespace DogApp.Data.EntityModels;


public class Item : BaseEntity
{

    public string? Description { get; set; }
   
    public string? Image { get; set; }
    
    public bool IsSign { get; set; }
   
    public string? Category { get; set; }
   
    public ICollection<TrackItem>? TrackItems { get; set; }

    public Item()
    {

    }
    public Item(int id, string name)
    {
        base.Id = id;
        this.Name = name;
    }
}