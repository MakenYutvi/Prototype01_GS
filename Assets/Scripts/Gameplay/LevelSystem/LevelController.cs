using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private LevelWindow _levelWindow;

    private ILevelManager _levelManager;
    
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
    }

    // Update is called once per frame
    private void OnLevelChanged(int level)
    {
        _levelWindow.SetLevelNumber(level);
    }

    private void OnExperienceChanged(float amountNormalized)
    {
        _levelWindow.SetExperienceBarSize(amountNormalized);
    }
}
