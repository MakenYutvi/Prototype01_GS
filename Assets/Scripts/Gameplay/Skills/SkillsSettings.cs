using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillSettingsData",
    menuName = "ScriptableObject/LevelSettings/SkillSettingsData")]

public class SkillsSettings : ScriptableObject
{
    [SerializeField]
    private List<SkillSetting> _skillsList;
    [SerializeField]
    private List<SkillName> _activeSkills;

    private int _avalableSkillPoints = 0;
    public int AvalableSkillPoints
    {
        get
        {
            return _avalableSkillPoints;
        }
        set
        {
            _avalableSkillPoints = value;
        }
    }

    public void AddToListActivateSkill( SkillName skillName)
    {
        if(!_activeSkills.Contains(skillName))
            _activeSkills.Add(skillName);
    }
    public List<SkillName> GetActiveSkills()
    {
        return _activeSkills;
    }
    public List<SkillName> GetRequireSkills(SkillName skillName)
    {
        return _skillsList.Find(x => x.skillName == skillName).requireSkills;
    }

    public int GetRequireLevel(SkillName skillName)
    {
        return _skillsList.Find(x => x.skillName == skillName).requireLevel;
    }
    public int GetSkillCost(SkillName skillName)
    {
        return _skillsList.Find(x => x.skillName == skillName).cost;
    }

    public void ClearActiveSkills()
    {
        _activeSkills.Clear();
    }
    
    [Serializable]
    private struct SkillSetting
    {
        [SerializeField]
        public SkillName skillName;
        [SerializeField]
        public List<SkillName> requireSkills;
        [SerializeField]
        public int requireLevel;
        [SerializeField]
        public int cost;
    }
}
