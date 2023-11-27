using FitnessClub.BL.Trainers.Entities;

namespace FitnessClub.BL.Trainers;

public interface ITrainersProvider
{
    IEnumerable<TrainerModel> GetTrainers(TrainersModelFilter modelFilter = null);
    TrainerModel GetTrainerInfo(Guid trainerId);
}