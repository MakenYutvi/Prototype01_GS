using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateManager : MonoBehaviour, ICameraStateManager
{
    [SerializeField]
    private CameraStateId stateId;

    private CameraState state;

    [SerializeField]
    private List<StateInfo> states;

    private Dictionary<CameraStateId, CameraState> cameraStateMap;

    private float fixedDeltaTime;
    
    public void SetState(CameraStateId stateId)
    {
        if (this.state != null)
        {
            this.state.OnExit();
        }

        var nextState = this.cameraStateMap[stateId];
        nextState.OnEnter();
        this.state = nextState;
    }

    private void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        this.cameraStateMap = new Dictionary<CameraStateId, CameraState>();
        foreach (var info in this.states)
        {
            this.cameraStateMap[info.id] = info.state;
        }
    }

    private void Start()
    {
        this.SetState(this.stateId);
    }

    private void FixedUpdate()
    {
        if (this.state != null)
        {
            this.state.OnUpdate(this.fixedDeltaTime);
        }
    }
    
    [Serializable]
    private struct StateInfo
    {
        [SerializeField]
        public CameraStateId id;

        [SerializeField]
        public CameraState state;
    }
}