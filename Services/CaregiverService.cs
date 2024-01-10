using Core;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services
{
    public class CaregiverService(AnimalDbContext dbContext)
    {
        public IList<Caregiver> Find()
        {
            return dbContext.Caregivers
                .Include(a => a.Animal)
                .ToList();
        }

        public Caregiver? Get(int id)
        {
            return dbContext.Caregivers
                .Include(a => a.Animal)
                .FirstOrDefault(p => p.Id == id);
        }

        public Caregiver? Create(Caregiver assignment)
        {
            dbContext.Caregivers.Add(assignment);
            dbContext.SaveChanges();

            return assignment;
        }

        public Caregiver? Update(int id, Caregiver assignment)
        {
            var dbAssignment = dbContext.Caregivers.FirstOrDefault(p => p.Id == id);

            if (dbAssignment is null)
            {
                return null;
            }

            dbAssignment.FirstName = assignment.FirstName;
            dbAssignment.LastName = assignment.LastName;
            dbAssignment.Email = assignment.Email;
            dbAssignment.PhoneNumber = assignment.PhoneNumber;
            dbAssignment.AnimalId = assignment.AnimalId;
            dbContext.SaveChanges();

            return assignment;
        }

        public void Delete(int id)
        {
            var dbAssignment = dbContext.Caregivers.FirstOrDefault(p => p.Id == id);

            if (dbAssignment is null)
            {
                return;
            }

            dbContext.Caregivers.Remove(dbAssignment);

            dbContext.SaveChanges();
        }
    }

}
