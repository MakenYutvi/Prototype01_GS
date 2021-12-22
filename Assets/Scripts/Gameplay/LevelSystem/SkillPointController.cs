using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkillPointController : MonoBehaviour
{

    [SerializeField]
    private LevelSettings _levelSettings;

    private ILevelManager _levelManager;
    private ISkillPointManager _skillPointManager;

    [Inject]
    public void Cunstruct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    
    [Inject]
    public void Cunstruct(ISkillPointManager skillPointManager)
    {
        _skillPointManager = skillPointManager;
    }

    private void Start()
    {
        _levelManager.OnLevelChanged += OnlevelChanged;
    }

    private void OnlevelChanged(int level)
    {
        _skillPointManager.AddSkillPoints(_levelSettings.GetSkillPointsForLevel(level));
    }
}
