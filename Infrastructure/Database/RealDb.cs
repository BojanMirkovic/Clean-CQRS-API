
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bird>().ToTable("Birds");
            modelBuilder.Entity<Dog>().ToTable("Dogs");
            modelBuilder.Entity<Cat>().ToTable("Cats");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Animal>().ToTable("Animals");
            //  Configuring many-to - many relationship between User and Animal through UserAnimal
            modelBuilder.Entity<UsersHaveAnimals>().ToTable("UsersHaveAnimals");



            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}
