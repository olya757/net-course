namespace FitnessClub.Service.Settings
{
    public class FitnessClubSettings
    {
        public string FitnessClubDbContextConnectionString { get; set; }
        public int MinimumTrainerAge { get; set; } = 18;
    }
}
