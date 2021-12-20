using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class WeaponSystemPistol : WeaponState
{
    [SerializeField]
    private List<WeaponComponentBase> _weaponComponents;//maybe two pistols

    private IAtackComponent _atackComponent;

    [Inject]
    public void Construct(IAtackComponent atackComponent)
    {
        _atackComponent = atackComponent;
    }

    public override void Attack()
    {
        _weaponComponents.ForEach(w => w.Attack());
        Debug.Log("Pistol Attack");
        Debug.Log("Pistol Attack2");
    }

    public override void OnActivate()
    {
        _weaponComponents.ForEach(w => w.OnActivate());
        _atackComponent.OnAttack += Attack;
        Debug.Log("Pistol OnActivate");
    }

    public override void OnDeactivate()
    {
        _weaponComponents.ForEach(w => w.OnDeactivate());
        _atackComponent.OnAttack -= Attack;
        Debug.Log("Pistol OnDeactivate");
    }
}

