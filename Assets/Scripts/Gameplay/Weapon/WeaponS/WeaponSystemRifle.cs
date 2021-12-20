using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class WeaponSystemRifle : WeaponState
{
    [SerializeField]
    private List<WeaponComponentBase> _weaponComponents;

    private IAtackComponent _atackComponent;

    [Inject]
    public void Construct(IAtackComponent atackComponent)
    {
        _atackComponent = atackComponent;
    }

    public override void Attack()
    {
        Debug.Log("Rifle Attack");

    }

    public override void OnActivate()
    {
        Debug.Log("Rifle OnActivate");
        _atackComponent.OnAttack += Attack;
    }

    public override void OnDeactivate()
    {
        Debug.Log("Rifle OnDeactivate");
        _atackComponent.OnAttack -= Attack;
    }
}

