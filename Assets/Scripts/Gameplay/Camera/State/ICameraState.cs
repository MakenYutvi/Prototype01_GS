public interface ICameraState
{
    void OnEnter();

    void OnUpdate(float deltaTime);

    void OnExit();
}