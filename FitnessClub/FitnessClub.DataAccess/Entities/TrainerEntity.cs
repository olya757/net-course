using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClub.DataAccess.Entities
{
    [Table("trainers")]
    public class TrainerEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }

        // ctrl+k+d+r+g+s
    }
}
