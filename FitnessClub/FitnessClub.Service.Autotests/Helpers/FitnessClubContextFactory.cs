using FitnessClub.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Service.Autotests.Helpers;

public class FitnessClubContextFactory : IDbContextFactory<FitnessClubDbContext>
{
    public FitnessClubDbContext CreateDbContext()
    {
        var settings = TestSettingsHelper.GetSettings();
        return new FitnessClubDbContext(new DbContextOptionsBuilder()
            .UseSqlServer(settings.FitnessClubDbContextConnectionString).Options);
    }
}