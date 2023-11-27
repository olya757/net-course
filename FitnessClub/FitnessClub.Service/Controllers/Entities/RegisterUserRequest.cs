using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Service.Controllers.Entities;

public class RegisterUserRequest : IValidatableObject
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public int ClubId { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        return errors;
    }
}