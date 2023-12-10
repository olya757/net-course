using AutoMapper;
using FitnessClub.BL.Trainers;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using FitnessClub.Service.Settings;

namespace FitnessClub.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, FitnessClubSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ITrainersProvider>(x =>
            new TrainersProvider(x.GetRequiredService<IRepository<TrainerEntity>>(), x.GetRequiredService<IMapper>(),
                settings.MinimumTrainerAge));
        services.AddScoped<ITrainersManager, TrainersManager>();
    }
}