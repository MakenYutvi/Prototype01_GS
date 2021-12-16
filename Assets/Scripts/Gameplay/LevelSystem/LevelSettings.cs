using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettingsData",
    menuName = "ScriptableObject/LevelSettings/LevelSettingsData")]
public class LevelSettings : ScriptableObject
{
    [SerializeField]
    private int[] _experienceAmountForLevel;

    public int ExperienceForNextLevel(int level)
    {
        if (level < GetMaxLevel())
            return _experienceAmountForLevel[level - 1];
        else
            return _experienceAmountForLevel[_experienceAmountForLevel.Length - 1];
    }

    public int GetMaxLevel()
    {
        return _experienceAmountForLevel.Length;
    }

    public bool IsMaxLevel(int level)
    {
        return _experienceAmountForLevel.Length <= level;
    }
}
