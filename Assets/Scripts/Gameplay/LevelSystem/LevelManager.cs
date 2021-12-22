using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour,  ILevelManager
{
    [SerializeField]
    private LevelSettings _levelSettings;

    [SerializeField]//for test
    private int _level = 1;

    public event Action<int> OnLevelChanged;

    
    public int ChangeLevel()
    {
        if (IsMaxLevel())
        {
            return _level;
        }
        else
        {
            _level++;
            OnLevelChanged?.Invoke(_level);
            return _level;
        }

        
    }

    public int GetCurrentLevel()
    {
        return _level;
    }

    public bool IsMaxLevel()
    {
        return _levelSettings.IsMaxLevel(_level);
    }
}
