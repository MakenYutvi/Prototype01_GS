using Otus.InventoryModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponChangeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private WeaponStateID _weaponStateID;
    private List<WeaponReloadController> _weaponReloadControllers;
    private IWeaponManager _weaponManager;

    [Inject]
    public void Construct(IWeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    private void Awake()
    {
        var controllers = GameObject.FindObjectsOfType<WeaponReloadController>();
        foreach(var controller in controllers)
        {
            controller.OnBulletsRunOut += OnBulletsRunOut;
         //   _weaponReloadControllers.Add(controller);
        }
        //foreach(var controller in _weaponReloadControllers)
        //{
        //    controller.OnBulletsRunOut += OnBulletsRunOut;
        //}
    }

    private void OnBulletsRunOut(WeaponStateID obj)
    {
        _weaponManager.SetState(_weaponStateID);
    }

}
