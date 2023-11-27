namespace FitnessClub.Service.Controllers.Entities;

public class TrainersFilter
{
    public int? MinimumAge { get; set; }
    public int? MaximumAge { get; set; }
    public bool? Sex { get; set; }
}