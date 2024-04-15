using Microsoft.EntityFrameworkCore;
using DogApp.Data.EntityModels;


namespace DogApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TrackItem> TrackItems { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "højre sving", Description = "", Image = "/images/hojresving", IsSign= true, Category = "Øvet"},
                new Item { Id = 2, Name = "venstre sving", Description = "", Image = "/images/venstresving", IsSign = true, Category = "Øvet" },
                new Item { Id = 3, Name = "højre rundt", Description = "", Image = "/images/hojrerundt", IsSign = true, Category = "Øvet" },
                new Item { Id = 4, Name = "venstre rundt", Description = "", Image = "/images/venstrerundt", IsSign = true, Category = "Øvet" },
                new Item { Id = 5, Name = "diagonalt højre", Description = "", Image = "/images/diagonalthojre", IsSign = true, Category = "Øvet" },

                new Item { Id = 6, Name = "Slalom med rundtur", Description = "", Image = "/images/Slalommedrundtur", IsSign = true, Category = "Expert"},
                new Item { Id = 7, Name = "Fristende otte tal", Description = "", Image = "/images/Fristendeottetal", IsSign = true, Category = "Expert" },
                new Item { Id = 8, Name = "Kløverbladet", Description = "", Image = "/images/Kløverbladet", IsSign = true, Category = "Expert" },
                new Item { Id = 9, Name = "Send over spring", Description = "", Image = "/images/sendoverspring", IsSign = true, Category = "Expert" },
                new Item { Id = 10, Name = "Stop bliv alm gang forbi et spring", Description = "", Image = "/images/stopblivalmgangforblivetspring", IsSign = true, Category = "Expert" }
            );

            modelBuilder.Entity<Track>().HasData(
               new Track { Id = 1, Name = "Rallybane 1", Height = 100, Width = 200, Category = " Champion" },
                new Track { Id = 2, Name = "Rallybane 2", Height = 150, Width = 250, Category = "Open " },
                new Track { Id = 3, Name = "Rallybane 3", Height = 120, Width = 180, Category = "Beginder" }
                );
        }
    }
}
