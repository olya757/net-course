using AutoMapper;
using FitnessClub.BL.Auth;
using FitnessClub.BL.Trainers;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using FitnessClub.Service.Settings;
using Microsoft.AspNetCore.Identity;

namespace FitnessClub.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, FitnessClubSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ITrainersProvider>(x =>
            new TrainersProvider(x.GetRequiredService<IRepository<TrainerEntity>>(), x.GetRequiredService<IMapper>(),
                settings.MinimumTrainerAge));
        services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        services.AddScoped<ITrainersManager, TrainersManager>();
    }
}