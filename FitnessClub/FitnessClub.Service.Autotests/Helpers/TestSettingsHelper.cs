using FitnessClub.Service.Settings;
using Microsoft.Extensions.Configuration;

namespace FitnessClub.Service.Autotests.Helpers;

public static class TestSettingsHelper
{
    public static FitnessClubSettings GetSettings()
    {
        return FitnessClubSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}