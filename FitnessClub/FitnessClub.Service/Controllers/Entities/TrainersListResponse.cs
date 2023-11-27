using FitnessClub.BL.Trainers.Entities;

namespace FitnessClub.Service.Controllers.Entities;

public class TrainersListResponse
{
    public List<TrainerModel> Trainers { get; set; }
}