using FitnessClub.BL.Mapper;
using FitnessClub.Service.Mapper;

namespace FitnessClub.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<TrainersBLProfile>();
            config.AddProfile<TrainersServiceProfile>();
        });
    }
}