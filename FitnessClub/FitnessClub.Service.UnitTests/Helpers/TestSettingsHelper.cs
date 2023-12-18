using FitnessClub.Service.Settings;

namespace FitnessClub.Service.UnitTests.Helpers;

public static class TestSettingsHelper
{
    public static FitnessClubSettings GetSettings()
    {
        return FitnessClubSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}