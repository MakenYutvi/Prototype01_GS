using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ECS
{
    class WeaponStateController :MonoBehaviour
    {
        [SerializeField]
        private MonoEntity _playerEntity;

        private PlayerInput _playerInput;
        public event Action OnAttack;
        void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.WeaponState1.performed += context => WeaponState1();
            _playerInput.Player.WeaponState2.performed += context => WeaponState2();
            _playerInput.Player.WeaponState3.performed += context => WeaponState3();

        }


        private void WeaponState1()
        {        
            if (_playerEntity.TryGetElement<IWeaponStateComponent>(out var element))
            {
                element.SetState(WeaponStateID.KNIFE);
            }
        }
        private void WeaponState2()
        {
            if (_playerEntity.TryGetElement<IWeaponStateComponent>(out var element))
            {
                element.SetState(WeaponStateID.PISTOL);
            }
        }
        private void WeaponState3()
        {         
            if (_playerEntity.TryGetElement<IWeaponStateComponent>(out var element))
            {
                element.SetState(WeaponStateID.RIFLE);
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
