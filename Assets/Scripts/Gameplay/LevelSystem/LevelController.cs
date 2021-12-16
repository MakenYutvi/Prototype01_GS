using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private LevelWindow _levelWindow;

    private bool _isAnimate = false;
    private int _level;
    private int _experience;
    private ILevelManager _levelManager;
    private float _updateTimer;
    private float _updateTimerMax = .016f;
    
    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    void Start()
    {
        _levelWindow.SetLevelNumber(_levelManager.GetLevel());
        _levelWindow.SetExperienceBarSize(_levelManager.GetExperienceNormalized());

        _levelManager.isExperienceChanged += OnExperienceChanged;
        _levelManager.isLevelChanged += OnLevelChanged;

        _level = _levelManager.GetLevel();
        _experience = _levelManager.GetExperience();
    }

    private void OnLevelChanged(int level)
    {
        //_levelWindow.SetLevelNumber(level);
        _isAnimate = true;
    }

    private void OnExperienceChanged(float amountNormalized)
    {
        //_levelWindow.SetExperienceBarSize(amountNormalized);
        _isAnimate = true;
    }

    private void Update()
    {
        if(_isAnimate)
        {
            _updateTimer += Time.deltaTime;
            if(_updateTimer > _updateTimerMax)
            {
                _updateTimer -= _updateTimerMax;
                UpdateTypeAddExperience();
            }          
        }       
    }

    private void UpdateTypeAddExperience()
    {
        if (_level < _levelManager.GetLevel() )
        {
            AddExperience();
        }
        else if (_experience < _levelManager.GetExperience() && !_levelManager.IsMaxLevel(_level))
        {
            AddExperience();
        }
        else
        {
            _isAnimate = false;
        }
    }
    private void AddExperience()
    {
        _experience++;
        _levelWindow.SetExperienceBarSize((float) _experience / _levelManager.GetExperienceForNextLevel(_level));
        if (_experience >= _levelManager.GetExperienceForNextLevel(_level))
        {
            _level++;
            _levelWindow.SetLevelNumber(_level);
            _experience = 0;
        }
    }
}
