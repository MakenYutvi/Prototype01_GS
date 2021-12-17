using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelSettingsData",
    menuName = "ScriptableObject/LevelSettings/LevelSettingsData")]
public class LevelSettings : ScriptableObject
{
    
    [SerializeField]
    private int[] _experienceAmountForLevel;

    [SerializeField]
    private List<LevelSetting> _levelsSettings;

   

    public int ExperienceForNextLevel(int level)
    {
        if (level < GetMaxLevel())
            return _levelsSettings.Find(h => h.level == level).experienceForNextLevel;
        else
            return _levelsSettings.Find(h => h.level == GetMaxLevel()).experienceForNextLevel;
    }

    public int GetMaxLevel()
    {
        return _levelsSettings.Count;
    }

    public bool IsMaxLevel(int level)
    {
        return _levelsSettings.Count <= level;
    }

    [Serializable]
    private struct LevelSetting
    {
        [SerializeField]
        public int level;
        [SerializeField]
        public int experienceForNextLevel;
        [SerializeField]
        public int skillPoints;
    }
}
