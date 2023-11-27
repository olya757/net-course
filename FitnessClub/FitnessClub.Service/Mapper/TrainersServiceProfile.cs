using AutoMapper;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.Service.Controllers.Entities;

namespace FitnessClub.Service.Mapper;

public class TrainersServiceProfile : Profile
{
    public TrainersServiceProfile()
    {
        CreateMap<TrainersFilter, TrainersModelFilter>();
        CreateMap<CreateTrainerRequest, CreateTrainerModel>(); 
    }
}