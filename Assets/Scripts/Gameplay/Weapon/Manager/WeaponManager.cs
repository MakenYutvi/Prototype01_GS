using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour, IWeaponManager 
{
    [SerializeField]
    private WeaponStateID stateId;

    private WeaponState state;

    [SerializeField]
    private List<WeaponInfo> states;

    private Dictionary<WeaponStateID, WeaponState> weaponStateMap;
    public void SetState(WeaponStateID stateId)
    {
        if (this.state != null)
        {
            this.state.OnDeactivate();
        }

        var nextState = this.weaponStateMap[stateId];
        nextState.OnActivate();
        this.state = nextState;
    }

    private void Awake()
    {
        this.weaponStateMap = new Dictionary<WeaponStateID, WeaponState>();
        foreach (var info in this.states)
        {
            this.weaponStateMap[info.id] = info.state;
        }
    }

    private void Start()
    {
        this.SetState(this.stateId);
    }

    [Serializable]
    private struct WeaponInfo
    {
        [SerializeField]
        public WeaponStateID id;

        [SerializeField]
        public WeaponState state;
    }
}
