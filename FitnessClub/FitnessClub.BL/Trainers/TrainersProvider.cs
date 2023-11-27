using AutoMapper;
using FitnessClub.BL.Helpers;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;

namespace FitnessClub.BL.Trainers;

public class TrainersProvider : ITrainersProvider
{
    private readonly IRepository<TrainerEntity> _trainerRepository;
    private readonly IMapper _mapper;

    public TrainersProvider(IRepository<TrainerEntity> trainersRepository, IMapper mapper, int minimumTrainerAge)
    {
        _trainerRepository = trainersRepository;
        _mapper = mapper;
    }

    public IEnumerable<TrainerModel> GetTrainers(TrainersModelFilter modelFilter = null)
    {
        var minimumAge = modelFilter?.MinimumAge;
        var maximumAge = modelFilter?.MaximumAge;
        var sex = modelFilter?.Sex;

        var currentDate = DateTime.UtcNow;

        var trainers = _trainerRepository.GetAll(x => (
            minimumAge == null ||
            AgeHelper.GetAge(x.Birthday) > minimumAge)); //add other filters

        return _mapper.Map<IEnumerable<TrainerModel>>(trainers);
    }

    public TrainerModel GetTrainerInfo(Guid trainerId)
    {
        var trainer = _trainerRepository.GetById(trainerId); //return null if not exists
        if (trainer is null)
        {
            throw new ArgumentException("Trainer not found.");
        }

        return _mapper.Map<TrainerModel>(trainer);
    }
}