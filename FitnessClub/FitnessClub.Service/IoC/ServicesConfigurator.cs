using FitnessClub.BL.Trainers;
using FitnessClub.DataAccess;

namespace FitnessClub.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ITrainersProvider, TrainersProvider>();
        services.AddScoped<ITrainersManager, TrainersManager>();
    }
}