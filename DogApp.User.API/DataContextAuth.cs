using DogApp.Shared.EntityModelsAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

public class DataContextAuth : IdentityDbContext
{
    public DataContextAuth(DbContextOptions<DataContextAuth> options)
        : base(options)
    {

    }

    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}
