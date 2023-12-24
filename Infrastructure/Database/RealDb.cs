
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
        
      /*  public DbSet<Animal> Animals { get; set; } */

        public DbSet<UsersHaveAnimals> UsersHaveAnimals { get; set; } //joint tableUsersAnimals

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-D4IQ7VEN\\SQLEXPRESS; Database=API_Animals; Trusted_Connection=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasKey(a => a.AnimalId);

            modelBuilder.Entity<Bird>().ToTable("Birds")
                .HasBaseType<Animal>()
                .Property(b => b.AnimalId)
                .HasColumnName("AnimalId");
            modelBuilder.Entity<Dog>().ToTable("Dogs")
                .HasBaseType<Animal>()
                .Property(d => d.AnimalId)
                .HasColumnName("AnimalId"); ;
            modelBuilder.Entity<Cat>().ToTable("Cats")
                .HasBaseType<Animal>()
                .Property(c => c.AnimalId)
                .HasColumnName("AnimalId"); ;
            modelBuilder.Entity<User>().ToTable("Users");
            //  modelBuilder.Entity<Animal>().ToTable("Animals");
            //  Configuring many-to - many relationship between User and Animal through UserAnimal
            modelBuilder.Entity<UsersHaveAnimals>().ToTable("UsersHaveAnimals");

            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }

    }
}
