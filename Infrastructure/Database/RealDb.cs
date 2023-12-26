
using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using Domain.Models.UserModel;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDb : DbContext
    {
        public RealDb()
        {
        }
        public RealDb(DbContextOptions<RealDb> options) : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<UsersHaveAnimals> UsersHaveAnimals { get; set; } //joint tableUsersAnimals

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-D4IQ7VEN\\SQLEXPRESS; Database=API_Animals; Trusted_Connection=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
          .HasKey(a => a.AnimalId);

            modelBuilder.Entity<Animal>()
                .ToTable("Animals"); // Separate table for Animal entity

            modelBuilder.Entity<Bird>()
                .ToTable("Birds")
                .HasBaseType<Animal>();

            modelBuilder.Entity<Dog>()
                .ToTable("Dogs")
                .HasBaseType<Animal>();

            modelBuilder.Entity<Cat>()
                .ToTable("Cats")
                .HasBaseType<Animal>();

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<UsersHaveAnimals>()
                .ToTable("UsersHaveAnimals");

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }
    }
}
