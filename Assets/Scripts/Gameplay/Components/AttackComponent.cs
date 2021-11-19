using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private WeaponComponent _weaponComponent;


    public void Attack(Ray ray)
    {
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);
        bool target = Physics.Raycast(ray, out RaycastHit hit);
        Vector3 direction;
        Vector3 point;
        if (target)
        {
            direction = (hit.point - this.transform.position).normalized;
            //Debug.DrawRay(this.transform.position, direction * 100, Color.blue, 1000);
        }
        else
        {
            point = ray.origin + ray.direction * 100;
            direction = (point - this.transform.position).normalized;
            //Debug.DrawRay(this.transform.position, direction * 100, Color.green, 1000);
        }

        _weaponComponent.Attack(direction);
    }
}