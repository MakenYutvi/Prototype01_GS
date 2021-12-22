using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkillController : MonoBehaviour, ISkillController
{
    [SerializeField]
    private SkillsSettings _skillsSettings;
    private ILevelManager _levelManager;
    private ISkillPointManager _skillPointManager;

    private int _playerLevel;

    public event Action<int> IsSkillPointsChanged;

    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    [Inject]
    public void Construct(ISkillPointManager skillPointManager)
    {
        _skillPointManager = skillPointManager;
    }

    private void Start()
    {
        _skillPointManager.OnSkillPointsChanged += AddSkillPoints;
        _levelManager.OnLevelChanged += LevelUp;
        _skillsSettings.ClearActiveSkills();
    }

    private void LevelUp(int value)
    {
        _playerLevel = value;
    }

    private void AddSkillPoints(int amount)
    {
        _skillsSettings.AvalableSkillPoints += amount;
        IsSkillPointsChanged?.Invoke(amount);
    }

    public bool IsUnlockedSkill(SkillName name)
    {
        var activeSkills = _skillsSettings.GetActiveSkills();
        if (activeSkills == null)
        {
            return false;
        }
        else if(activeSkills.Contains(name))
        {
            return true;
        }

        return false;
    }

    public bool TryToUnlockSkill(SkillName name)
    {
       if(IsUnlockedSkill(name))
        {
            return false;
        }
        var requireCost = _skillsSettings.GetSkillCost(name);
        if (_skillsSettings.GetSkillCost(name) > _skillsSettings.AvalableSkillPoints)
            return false;
        var reuireLevel = _skillsSettings.GetRequireLevel(name);
        if (_playerLevel < reuireLevel)
            return false;
        var requireSkills = _skillsSettings.GetRequireSkills(name);
        if (requireSkills !=  null)
        {
            foreach (var skill in requireSkills)
            {
                if (!_skillsSettings.GetActiveSkills().Contains(skill))
                {
                    return false;
                }
            }
        }
        _skillsSettings.AvalableSkillPoints -= requireCost;
        _skillsSettings.AddToListActivateSkill(name);
        IsSkillPointsChanged?.Invoke(-requireCost);

        return true;


    }

    public List<SkillName> GetActiveSpells()
    {
        return _skillsSettings.GetActiveSkills();
    }
}
