using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerInput _playerInput;
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Fire.performed += context => OnShoot();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    // Update is called once per frame
    
    private void OnShoot()
    {
        Debug.Log("debug shoot");
    }
}
