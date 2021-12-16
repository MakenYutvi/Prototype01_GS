using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelWindow : MonoBehaviour
{
    //[SerializeField] private Text _levelText;
    [SerializeField] private Image _experienceBarImage;
    [SerializeField] private TMP_Text _levelText;

    private void Awake()
    {
        SetExperienceBarSize(.0f);
        SetLevelNumber(1);
    }
    public void SetExperienceBarSize(float experienceNormalized)
    {
        _experienceBarImage.fillAmount = experienceNormalized;
    }

    public void SetLevelNumber(int levelNumber)
    {
        _levelText.text = levelNumber.ToString();
    }
}
