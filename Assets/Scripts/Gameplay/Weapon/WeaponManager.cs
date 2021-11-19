using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour, IWeaponManager //задел на будущее
{
    // Start is called before the first frame update
    [SerializeField]
    private WeaponComponent _defaultWeaponComponent;
    private WeaponComponent _WeaponComponent;

    private void Awake()
    {
        _WeaponComponent = _defaultWeaponComponent;
    }
    public void Attack(Vector3 direction)
    {
        _WeaponComponent.Attack(direction);
     }
}
