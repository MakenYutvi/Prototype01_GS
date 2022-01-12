using System.Collections;
using System.Collections.Generic;
using ECS;
using UnityEngine;

public class ReloadInputController : MonoBehaviour
{

    [SerializeField]
    private MonoEntity _player;
    
    private void Reload()
    {
        if (this._player.TryGetElement(out IReloadElement element) && element.CanReload())
        {
            element.Reload();
        }
    }
}
