public interface ILevelManager
{
    public event Action<int> isLevelChanged;
    public event Action<float> isExperienceChanged;

    public void AddExperience(int amount);
    public int GetLevel();
    public float GetExperienceNormalized();
    public int GetExperience();
    public int GetExperienceForNextLevel(int level);

    public bool IsMaxLevel(int level);

}
