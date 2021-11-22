using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointsComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _MaxHP = 10.0f;
    [SerializeField] private TextMesh _healthBar;
    private bool CanDamage;
    private float _hp;

    void Start()
    {
        _hp = _MaxHP;
        _healthBar.text = _hp.ToString();
    }

    public float GetDamage(float hitPoints)
    {
        _hp = Mathf.Max(0, _hp - hitPoints);
        _healthBar.text = _hp.ToString();
        return _hp;
    }
    public float GetHeal(float hitPoints)
    {
        return _hp = Mathf.Min(_hp + hitPoints, _MaxHP);
        _healthBar.text = _hp.ToString();
        return _hp;
    }

   
}
