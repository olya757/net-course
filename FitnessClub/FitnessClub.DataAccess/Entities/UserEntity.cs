using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FitnessClub.DataAccess.Entities;

[Table("users")]
public class UserEntity : IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime Birthday { get; set; }
    
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }

    public int ClubId { get; set; }
    public ClubEntity Club { get; set; }
}

public class UserRoleEntity : IdentityRole<int>
{
}