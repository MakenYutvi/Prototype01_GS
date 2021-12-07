using UnityEngine;

public abstract class CameraState : MonoBehaviour, ICameraState
{
    public virtual void OnEnter()
    {
    }

    public virtual void OnUpdate(float deltaTime)
    {
    }

    public virtual void OnExit()
    {
    }
}
