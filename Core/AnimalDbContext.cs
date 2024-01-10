using Microsoft.EntityFrameworkCore;
using Model;

namespace Core
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Caregiver> Caregivers => Set<Caregiver>();

        public void Seed()
        {
            Animals.AddRange(new List<Animal>
            {
                new Animal { Name = "Lion", Description = "Ferocious predator", Birthdate = DateTime.Parse("2022-01-01 09:30"), Gender = "Male"},
                new Animal { Name = "Elephant", Description = "Gentle giant", Birthdate = DateTime.Parse("2020-05-15 15:45"), Gender = "Female" },
                new Animal { Name = "Zebra", Description = "Striped beauty", Birthdate = DateTime.Parse("2021-07-10 12:20"), Gender = "Male"},
            });

            Caregivers.AddRange(new List<Caregiver>
            {
                new Caregiver { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "0473329051", AnimalId = 1},
                new Caregiver { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "0473329052" },
            });

           

            SaveChanges();
        }
    }
}
