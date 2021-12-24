using Otus.InventoryModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsCounterControllerUI : MonoBehaviour
{
    [SerializeField]
    private List<WeaponReloadController> _weaponReloadControllers;

    [SerializeField]
    private BulletsCounterUI _bulletsCounterUI;

    private void Awake()
    {
        foreach(var controller in _weaponReloadControllers)
        {
            
            controller.OnWeaponReloadControllerDisabled += OnWeaponReloadControllerDisabled;
            controller.OnBulletsTypeChanged += OnBulletsTypeChanged;
            controller.OnBulletsCountChanged += OnBulletsCountChanged;
        }
    }

    private void OnWeaponReloadControllerDisabled()//костыль
    {
        _bulletsCounterUI.SetTypeOfBullets("Knife");
        _bulletsCounterUI.SetCurrentBulletsInClipSize(" ");
        _bulletsCounterUI.SetBulletsInClipSize(" ");
        _bulletsCounterUI.SetBulletsInInventary(" ");
    }

    private void OnBulletsCountChanged(int amount)
    {
        _bulletsCounterUI.SetCurrentBulletsInClipSize(amount.ToString());
    }

    private void OnBulletsTypeChanged(WeaponStateID item, int currentCount, int clipSize, int countInInventory)
    {
        _bulletsCounterUI.SetTypeOfBullets(item.ToString());
        _bulletsCounterUI.SetCurrentBulletsInClipSize(currentCount.ToString());
        _bulletsCounterUI.SetBulletsInClipSize(clipSize.ToString());
        _bulletsCounterUI.SetBulletsInInventary(countInInventory.ToString());
    }
}
