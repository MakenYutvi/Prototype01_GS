
public interface IDamageController 
{
    public event Action<bool> IsPlayerDied;
    public void Subscribe(WeaponComponent weaponComponent);
    public void UnSubscribe(WeaponComponent weaponComponent);
}
