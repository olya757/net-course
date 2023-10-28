namespace FitnessClub.WebAPI.Settings
{
    public static class FitnessClubSettingsReader
    {
        public static FitnessClubSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new FitnessClubSettings();
        }
    }
}
