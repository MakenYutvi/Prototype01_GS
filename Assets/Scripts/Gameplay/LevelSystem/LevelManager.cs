using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, ILevelManager
{

    [SerializeField]
    private LevelSettings _levelSettings;
    public event Action<int> isLevelChanged;
    public event Action<float> isExperienceChanged;

    private int _level;
    private int _experience;

    private void Awake()
    {
        _level = 1;
        _experience = 0;
    }
    public void AddExperience(int amount)
    {
        if (_levelSettings.IsMaxLevel(_level))
            return;

        _experience += amount;
        while (_experience >= _levelSettings.ExperienceForNextLevel(_level) && !_levelSettings.IsMaxLevel(_level))
        {
            _level++;
            isLevelChanged?.Invoke(_level);
            _experience -= _levelSettings.ExperienceForNextLevel(_level);
            
        }
        isExperienceChanged?.Invoke(GetExperienceNormalized());
    }

    public int GetLevel()
    {
        return _level;
    }

    public float GetExperienceNormalized()
    {
        if (_levelSettings.IsMaxLevel(_level))
            return 1.0f;
        else
            return (float) _experience / _levelSettings.ExperienceForNextLevel(_level);
    }
}
