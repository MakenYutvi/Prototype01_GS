using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ExperienceControllerUI : MonoBehaviour, IExperienceControllerUI
{

    [SerializeField]
    private LevelWindow _levelWindow;

    private bool _isAnimate = false;
    private int _level;
    private int _experience;
    private int _addedExperience = 0;
    private ILevelManager _levelManager;
    private IExperienceManager _experienceManager;
    private float _updateTimer;
    private float _updateTimerMax = .006f;

    public event Action<int> OnLevelChange;

    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    [Inject]
    public void Construct(IExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
    }
    void Start()
    {
        _levelWindow.SetExperienceBarSize(_experienceManager.GetExperienceProgress());

        _experienceManager.OnExperienceChanged += OnExperienceChanged;

        _level = _levelManager.GetCurrentLevel();
        _experience = _experienceManager.GetExperience();
    }

  

    private void OnExperienceChanged(int amount)
    {
        var barZise = _experienceManager.GetExperienceProgress();
        _levelWindow.SetExperienceBarSize(barZise);
    }

}
