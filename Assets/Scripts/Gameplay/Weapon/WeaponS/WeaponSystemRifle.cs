using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class WeaponSystemRifle : WeaponState
{
    [SerializeField]
    private List<WeaponComponentBase> _weaponComponents;
    [SerializeField]
    private WeaponReloadController _WeaponReloadController;
    private IAtackComponent _atackComponent;

    [Inject]
    public void Construct(IAtackComponent atackComponent)
    {
        _atackComponent = atackComponent;
    }

    public override void Attack()
    {
        if (!_WeaponReloadController.CanAttack())
        {
            Debug.Log("Rifle cant Attack");
            return;
        }
        Debug.Log("Rifle Attack");

    }

    public override void OnActivate()
    {
        Debug.Log("Rifle OnActivate");
        _atackComponent.OnAttack += Attack;
        _WeaponReloadController.OnEnable();
    }

    public override void OnDeactivate()
    {
        Debug.Log("Rifle OnDeactivate");
        _atackComponent.OnAttack -= Attack;
        _WeaponReloadController.OnDisable();
    }
}

