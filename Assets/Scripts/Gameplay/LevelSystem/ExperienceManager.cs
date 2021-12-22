using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ExperienceManager : MonoBehaviour, IExperienceManager
{
    [SerializeField]
    private LevelSettings _levelSettings;

    [SerializeField]
    private int _experience;

    private ILevelManager _levelManager;

    public event Action<int> OnExperienceChanged;

    [Inject]
    public void Cunstruct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    private void Start()
    {
        _experience = 0;
    }

    public void AddExperience(int amount)
    {
        if (_levelManager.IsMaxLevel())
            return;

        _experience += amount;
        OnExperienceChanged?.Invoke(_experience);
        while (_experience >= _levelSettings.ExperienceForNextLevel(_levelManager.GetCurrentLevel()) && !_levelManager.IsMaxLevel())
        {
            _experience -= _levelSettings.ExperienceForNextLevel(_levelManager.GetCurrentLevel());           
            _levelManager.ChangeLevel();
            OnExperienceChanged?.Invoke(_experience);


        }
    }

    public int GetExperience()
    {
        return _experience;
    }

    public int GetExperienceForLevel(int level)
    {
        return _levelSettings.ExperienceForNextLevel(level);
    }

    public float GetExperienceProgress()
    {
        if (_levelManager.IsMaxLevel())
            return 1.0f;
        else
            return (float)_experience / _levelSettings.ExperienceForNextLevel(_levelManager.GetCurrentLevel());
    }
}
