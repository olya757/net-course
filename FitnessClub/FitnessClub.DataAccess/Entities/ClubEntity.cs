using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClub.DataAccess.Entities;

[Table("clubs")]
public class ClubEntity : BaseEntity
{
    public string Title { get; set; }
}