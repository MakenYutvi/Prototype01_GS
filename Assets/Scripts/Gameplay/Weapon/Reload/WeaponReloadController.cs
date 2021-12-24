using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Otus.InventoryModule;
using Zenject;

public class WeaponReloadController : MonoBehaviour
{
    [SerializeField]
    private WeaponStateID _weaponStateID;
    [SerializeField]
    private Item _item;
    [SerializeField]
    private int _clipSize;
    [SerializeField]
    private float _reloadTime;

    private bool _activeReload = false;
    private int _bulletsInClip = 0;
    private IInventoryItemManager _inventoryItemManager;

    public event Action<WeaponStateID> OnBulletsRunOut;
    public event ActionBulletsTypeChanged<WeaponStateID> OnBulletsTypeChanged;
    public event Action<int> OnBulletsCountChanged;
    public event Action<int> OnBulletsCountChangedInInvetory;
    public event Action OnWeaponReloadControllerDisabled;

    [Inject]
    public void Construct(IInventoryItemManager inventoryItemManager)
    {
        _inventoryItemManager = inventoryItemManager;
    }

    public void OnEnable()
    {
        OnBulletsTypeChanged?.Invoke(_weaponStateID, _bulletsInClip, _clipSize, _inventoryItemManager.GetCountsOfItems(_item));
    }

    public void OnDisable()
    {
        OnWeaponReloadControllerDisabled?.Invoke();
    }
    public bool CanAttack()
    {
        if(_bulletsInClip > 0)
        {
            _bulletsInClip--;
            OnBulletsCountChanged?.Invoke(_bulletsInClip);
            if (_bulletsInClip == 0)
            {
                OnBulletsRunOut?.Invoke(_weaponStateID);
            }
            return true;
        }
        else
        {
            if(_inventoryItemManager.ContainsItem(_item) && !_activeReload)
            {
                StartCoroutine(Reload());
                
            }
            return false;
        }
       
    }

    private int GetCountBullets()
    {
        return 0;
    }

    private bool IsEnoughBullets()
    {
        return true;
    }

    private IEnumerator Reload()
    {
        Debug.Log("reload started");
        _activeReload = true;
        yield return new WaitForSeconds(_reloadTime);
        Debug.Log("reload ended");
        int count = _inventoryItemManager.GetCountsOfItems(_item);
        _bulletsInClip = Mathf.Min(_clipSize, count);
        OnBulletsCountChanged?.Invoke(_bulletsInClip);
        _inventoryItemManager.RemoveNItems(_item, _bulletsInClip);
        count = _inventoryItemManager.GetCountsOfItems(_item);
        OnBulletsCountChangedInInvetory?.Invoke(count);
        _activeReload = false;

    }

}
