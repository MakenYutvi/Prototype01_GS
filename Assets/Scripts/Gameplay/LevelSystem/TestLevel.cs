using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestLevel : MonoBehaviour
{
    
    [SerializeField]
    private Button _button50Xp;
    [SerializeField]
    private Button _button150Xp;
    [SerializeField]
    private Button _button500Xp;

    private ILevelManager _levelManager;

    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }

    private void OnEnable()
    {
        _button50Xp.onClick.AddListener(this.AddExperience50);
        _button150Xp.onClick.AddListener(this.AddExperience150);
        _button500Xp.onClick.AddListener(this.AddExperience500);
    }

    private void OnDisable()
    {
        _button50Xp.onClick.RemoveListener(this.AddExperience50);
        _button150Xp.onClick.RemoveListener(this.AddExperience150);
        _button500Xp.onClick.RemoveListener(this.AddExperience500);
    }

    private void AddExperience50()
    {
        _levelManager.AddExperience(50);
    }
     private void AddExperience150()
    {
        _levelManager.AddExperience(150);
    }
     private void AddExperience500()
    {
        _levelManager.AddExperience(500);
    }

}
