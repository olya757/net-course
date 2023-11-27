using AutoMapper;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.DataAccess.Entities;

namespace FitnessClub.BL.Mapper;

public class TrainersBLProfile : Profile
{
    public TrainersBLProfile()
    {
        CreateMap<TrainerEntity, TrainerModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
            .ForMember(x => x.FullName, y => y.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        CreateMap<CreateTrainerModel, TrainerEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x=>x.ExternalId, y=>y.Ignore())
            .ForMember(x=>x.ModificationTime, y=>y.Ignore())
            .ForMember(x=>x.CreationTime, y=>y.Ignore());
        

    }
}