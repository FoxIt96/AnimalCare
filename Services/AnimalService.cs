using Core;
using System;
using Model;

namespace Services
{
    public class AnimalService(AnimalDbContext dbContext)
    {
        public IList<Animal> Find()
        {
            return dbContext.Animals
                .ToList();
        }

        public Animal? Get(int id)
        {
            return dbContext.Animals
                .FirstOrDefault(p => p.Id == id);
        }

        public Animal? Create(Animal animal)
        {
            dbContext.Animals.Add(animal);
            dbContext.SaveChanges();

            return animal;
        }

        public Animal? Update(int id, Animal animal)
        {
            var dbAnimal = dbContext.Animals.FirstOrDefault(p => p.Id == id);

            if (dbAnimal is null)
            {
                return null;
            }

            dbAnimal.Name = animal.Name;
            dbAnimal.Gender = animal.Gender;
            dbAnimal.Birthdate = animal.Birthdate;
            dbAnimal.Description= animal.Description;
            

            dbContext.SaveChanges();

            return animal;
        }

        public void Delete(int id)
        {
            var dbPerson = dbContext.Animals.FirstOrDefault(p => p.Id == id);

            if (dbPerson is null)
            {
                return;
            }

            dbContext.Animals.Remove(dbPerson);

            dbContext.SaveChanges();
        }
    }
}
