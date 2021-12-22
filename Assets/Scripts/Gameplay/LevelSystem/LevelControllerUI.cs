using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelControllerUI : MonoBehaviour
{

    [SerializeField]
    private LevelWindow _levelWindow;

    private int _level;
    private ILevelManager _levelManager;
    
    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }
 
    void Start()
    {
        _level = _levelManager.GetCurrentLevel();
        _levelWindow.SetLevelNumber(_level);
        _levelManager.OnLevelChanged += OnLevelChanged;

       
    }

    private void OnLevelChanged(int level)
    {
        _levelWindow.SetLevelNumber(level);
    }

}
