using Otus.InventoryModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketVisibilityController : MonoBehaviour
{
    [SerializeField]
    private GameObject _rocketGO;

    [SerializeField]
    private WeaponReloadController _weaponReloadController;

    private void Awake()
    {
        _weaponReloadController.OnBulletsRunOut += OnBulletsRunOut;
    }

    private void OnBulletsRunOut(WeaponStateID obj)
    {
        _rocketGO.SetActive(false);
    }
}
