using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogApp.Data.EntityModels;

public class TrackItem
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("ItemId")]
    public Item? Item;
    public int Itemid { get; set; }

    [ForeignKey("TrackId")]
    public Track? Track;
    public int Trackid { get; set; }

    public float? X { get; set; }
    public float? Y { get; set; }

    public int? Order { get; set; }


}