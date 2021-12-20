using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class WeaponSystemKnife : WeaponState
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
        Debug.Log("knife Attack");
    }

    public override void OnActivate()
    {
        Debug.Log("knife OnActivate");
        _atackComponent.OnAttack += Attack;
    }

    public override void OnDeactivate()
    {
        Debug.Log("knife OnDeactivate");
        _atackComponent.OnAttack -= Attack;
    }
}

