
public interface ILevelManager
{
    event Action<int> OnLevelChanged;
    int GetCurrentLevel();
    int ChangeLevel();

    bool IsMaxLevel();
}
