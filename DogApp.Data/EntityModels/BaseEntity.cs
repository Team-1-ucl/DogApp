namespace DogApp.Data.EntityModels;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
}