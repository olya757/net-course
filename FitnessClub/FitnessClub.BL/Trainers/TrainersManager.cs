using AutoMapper;
using FitnessClub.BL.Helpers;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;

namespace FitnessClub.BL.Trainers;

public class TrainersManager : ITrainersManager
{
    private readonly IRepository<TrainerEntity> _trainersRepository;
    private readonly IMapper _mapper;
    
    public TrainersManager(IRepository<TrainerEntity> trainersRepository, IMapper mapper)
    {
        _trainersRepository = trainersRepository;
        _mapper = mapper;
    }
    
    public TrainerModel CreateTrainer(CreateTrainerModel model)
    {
        if (AgeHelper.GetAge(model.Birthday) < 18)
        {
            throw new ArgumentException("Age must be greater than 18.");
        }

        var entity = _mapper.Map<TrainerEntity>(model);

        _trainersRepository.Save(entity); //id, modification, externalId

        return _mapper.Map<TrainerModel>(entity);
    }
    
    //void DeleteTrainer(Guid trainerId)
    //entity = repository.GetById() => if null throw exception
    //delete if not null
    
    //TrainerModel UpdateTrainer(UpdateTrainerModel model) //with Id
    //validate data
    //entity = repository.GetById(id) => if null throw exception
    //entity.FirstName = model.FirstName ...
    //save(entity)
    //return _mapper.Map<TrainerModel>(entity);
}