using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS
{
    public class AttackInputController : MonoBehaviour
    {
        [SerializeField]
        private Entity _playerEntity;

        private PlayerInput _playerInput;
        public event Action OnAttack;
        void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Fire.performed += context => Attack();
           
        }


        private void Attack()
        {
            OnAttack?.Invoke();
            Debug.Log("debug: attack AttackInputController");
            if (_playerEntity.GetComponentInChildren<AttackComponent>())
            {
                //component.Attack();
            }
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

    }
}