namespace FitnessClub.BL.Helpers;

public static class AgeHelper
{
    public static int GetAge(DateTime birthdayDateTime)
    {
        var now = DateTime.UtcNow; //01 01 2023
        int age = now.Year - birthdayDateTime.Year; // 1 02 2003 20 лет
        if (birthdayDateTime > now.AddYears(-age)) age--; // 27 11 2003
        return age;
    }
}