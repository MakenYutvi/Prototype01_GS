using Otus.InventoryModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RocketVisibilityController : MonoBehaviour
{
    [SerializeField]
    private GameObject _rocketGO;

    [SerializeField]
    private WeaponReloadController _weaponReloadController;

    private IInventoryItemManager _inventoryItemManager;

    [Inject]
    public void Construct(IInventoryItemManager inventoryItemManager)
    {
        _inventoryItemManager = inventoryItemManager;
    }


    private void Awake()
    {
        _weaponReloadController.OnBulletsRunOut += OnBulletsRunOut;
        _inventoryItemManager.OnItemAdded += OnItemAdded;
    }

    private void OnItemAdded(Item item)
    {
        if(false)
        {
            _rocketGO.SetActive(true);//на будещее, если будет норм инвентарь
        }
    }

    private void OnBulletsRunOut(WeaponStateID obj)
    {
        _rocketGO.SetActive(false);
    }
}
