using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ECS
{
    class WeaponStateController
    {
        [SerializeField]
        private MonoEntity _playerEntity;

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
            if (_playerEntity.TryGetElement<IWeaponStateComponent>(out var element))
            {
                //to do
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
