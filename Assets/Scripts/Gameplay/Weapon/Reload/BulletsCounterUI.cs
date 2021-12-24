using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsCounterUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _typeOfBullets;
    [SerializeField]
    private TMP_Text _currentBulletsInClipSize;
    [SerializeField]
    private TMP_Text _bulletsInClipSize;
    [SerializeField]
    private TMP_Text _bulletsInInventary;


    public void SetTypeOfBullets(string text)
    {
        _typeOfBullets.text = text;
    }
    public void SetCurrentBulletsInClipSize(string text)
    {
        _currentBulletsInClipSize.text = text;
    }
    public void SetBulletsInClipSize(string text)
    {
        _bulletsInClipSize.text = text;
    } 
    public void SetBulletsInInventary(string text)
    {
        _bulletsInInventary.text = text;
    }
    
}
