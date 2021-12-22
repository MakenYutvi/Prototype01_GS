
public interface IExperienceManager
{
    event Action<int> OnExperienceChanged;
    void AddExperience(int amount);
    int GetExperience();
    float GetExperienceProgress();
    int GetExperienceForLevel(int level);
}
