using UnityEngine;
public interface IAtackComponent 
{
    public event Action OnAttack;

    public void Attack(Ray ray);
}
