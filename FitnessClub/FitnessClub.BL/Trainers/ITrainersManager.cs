using FitnessClub.BL.Trainers.Entities;

namespace FitnessClub.BL.Trainers;

public interface ITrainersManager
{
    TrainerModel CreateTrainer(CreateTrainerModel model);
    //DeleteTrainer(id);
    //UpdateTrainer(id, model);
}