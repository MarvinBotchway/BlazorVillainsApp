using Microsoft.EntityFrameworkCore;

namespace BlazorVillainsApp.Server.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext( DbContextOptions<DatabaseContext> options ) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComicModel>().HasData
            (
                new ComicModel() { Id = 1, Name = "DC" },
                new ComicModel() { Id = 2, Name = "Marvel" }
            );

            modelBuilder.Entity<VillainModel>().HasData
            (

                new VillainModel()
                {
                    Id = 1,
                    FirstName = "Jack",
                    LastName = "Napier",
                    VillainName = "Venom",
                    ComicId = 2
                },
                new VillainModel()
                {
                    Id = 2,
                    FirstName = "Eddie",
                    LastName = "Brock",
                    VillainName = "Joker",
                    ComicId = 1
                }
                );

        }

        public DbSet<ComicModel> Comics { get; set; }
        public DbSet<VillainModel> Villains { get; set; }

    }
}
