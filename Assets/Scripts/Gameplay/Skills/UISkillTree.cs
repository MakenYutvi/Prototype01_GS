using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class UISkillTree : MonoBehaviour
{
    [SerializeField]
    private List<ButtonSkill> _buttonSkills;
    [SerializeField]
    private TMP_Text _avaliableSkillsValue;

    private int _availableSkills;

    private ISkillController _skillController;

    [Inject]
    public void Construct(ISkillController skillController)
    {
        _skillController = skillController;
    }
    private void Start()
    {
        _skillController.IsSkillPointsChanged += SkillsPointUpdate;
        _availableSkills = 0;
        _avaliableSkillsValue.text = _availableSkills.ToString();
        //var ActiveSkills = _skillController.GetActiveSpells();
        //foreach(var skill in ActiveSkills)
        //{
        //    _buttonSkills.Find(x => x.skillName == skill).button.GetComponent<Image>().color = Color.green;
        //}


    }
    private void OnEnable()
    {
        foreach(var buttonSkill in _buttonSkills)
        {
            buttonSkill.button.onClick.AddListener( () => this.TryToUnlockSkill(buttonSkill));
        }
    }
    private void OnDisable()
    {
        foreach (var buttonSkill in _buttonSkills)
        {
            buttonSkill.button.onClick.RemoveListener(() => this.TryToUnlockSkill(buttonSkill));
        }
    }

    private void TryToUnlockSkill(ButtonSkill buttonSkill)
    {
        //Debug.Log("try unclock skill:" + skillName);
        bool success = _skillController.TryToUnlockSkill(buttonSkill.skillName);
        if(success)
        {
            Debug.Log("unlcoked:" + buttonSkill.skillName);
            buttonSkill.button.GetComponent<Image>().color = Color.green;
        }
            
        else
        {
            Debug.Log("cant unlock:" + buttonSkill.skillName);
        }
            
    }
    private void SkillsPointUpdate(int amount)
    {
        _availableSkills += amount;
        _avaliableSkillsValue.text = _availableSkills.ToString();
    }

    [Serializable]
    private struct ButtonSkill
    {
        [SerializeField]
        public Button button;
        [SerializeField]
        public SkillName skillName;
    }
        
}
