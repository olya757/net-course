namespace FitnessClub.BL.Trainers.Entities;

public class TrainerModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Sex { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}