using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private GameObject _applicationSceneManagerGO;
    private ISceneManager _sceneManager;
    private IDamageController _damageController;

    [Inject]
    public void Construct(IDamageController damageController)
    {
        _damageController = damageController;
    }
    private void Awake()
    {
        this._sceneManager = this._applicationSceneManagerGO.GetComponent<ISceneManager>();
        _damageController.IsPlayerDied += LoadSceneAsync;
    }

    public void LoadSceneAsync(bool IsDead)
    {
        this._sceneManager.LoadSceneAsync("GameMainMenu3");
    }

}
