using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Gender { get; set; }

        public List<Caregiver> AssignedCaregivers { get; set; } = new List<Caregiver>();
    }
}
