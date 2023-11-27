namespace FitnessClub.BL.Trainers.Entities;

public class CreateTrainerModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Sex { get; set; }
    public DateTime Birthday { get; set; }
    public string Position { get; set; }
}