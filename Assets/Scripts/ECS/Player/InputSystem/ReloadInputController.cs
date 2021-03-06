using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS
{
    public class ReloadInputController : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity _playerEntity;

        private PlayerInput _playerInput;
        public event Action OnAttack;
        void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Reload.performed += context => Reload();

        }


        private void Reload()
        {
            OnAttack?.Invoke();
            Debug.Log("debug: Reload ReloadInputController");
            if (_playerEntity.TryGetElement<IReloadComponent>(out var element) && element.CanReload())
            {
                element.Reload();
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