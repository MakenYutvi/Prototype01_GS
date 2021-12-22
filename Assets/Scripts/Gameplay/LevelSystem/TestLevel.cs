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

    private IExperienceManager _experienceManager;

    [Inject]
    public void Construct(IExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
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
        _experienceManager.AddExperience(50);
    }
     private void AddExperience150()
    {
        _experienceManager.AddExperience(150);
    }
     private void AddExperience500()
    {
        _experienceManager.AddExperience(500);
    }

}
