using AutoMapper;
using FitnessClub.Service.Mapper;

namespace FitnessClub.BL.UnitTests.Mapper;

public static class MapperHelper
{
    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(TrainersServiceProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }

    public static IMapper Mapper { get; }
}