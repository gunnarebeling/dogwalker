using Microsoft.EntityFrameworkCore;
using DogWalker.Models;

namespace DogWalker.Data;

    public class DogWalkerDbContext : DbContext
    {
        public DogWalkerDbContext(DbContextOptions<DogWalkerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity properties and relationships here
            modelBuilder.Entity<Dog>().HasData(new Dog []
            {
                new Dog { Id = 1, Name = "Fido", Breed = "Golden Retriever", Age = 3, OwnerName = "Sue" },
                new Dog { Id = 2, Name = "Rex", Breed = "German Shepherd", Age = 4, OwnerName = "Bob" },
                new Dog { Id = 3, Name = "Spot", Breed = "Dalmatian", Age = 2, OwnerName = "Joe" }
            });
        }
    }

    