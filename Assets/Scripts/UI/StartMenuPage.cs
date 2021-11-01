using Scene;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public sealed class StartMenuPage : MonoBehaviour
{
    [FormerlySerializedAs("BattleSceneName1")]
    [SerializeField]
    private string battleSceneName1;

    [FormerlySerializedAs("BattleSceneName2")]
    [SerializeField]
    private string battleSceneName2;

    [FormerlySerializedAs("PlayButtonLevel1")]
    [SerializeField]
    private Button playButtonLevel1;

    [FormerlySerializedAs("PlayButtonLevel2")]
    [SerializeField]
    private Button playButtonLevel2;
    
    [FormerlySerializedAs("LoadingLogic")]
    [SerializeField]
    private GameObject sceneManagerGO;

    private ISceneManager sceneManager;
    
    private void Awake()
    {
        this.sceneManager = this.sceneManagerGO.GetComponent<ISceneManager>();
    }

    private void OnEnable()
    {
        this.playButtonLevel1.onClick.AddListener(this.OnButton1Clicked);
        this.playButtonLevel2.onClick.AddListener(this.OnButton2Clicked);
    }

    private void OnDisable()
    {
        this.playButtonLevel1.onClick.RemoveListener(this.OnButton1Clicked);
        this.playButtonLevel2.onClick.RemoveListener(this.OnButton2Clicked);
    }

    private void OnButton1Clicked()
    {
        this.sceneManager.LoadSceneAsync(this.battleSceneName1);
    }

    private void OnButton2Clicked()
    {
        this.sceneManager.LoadSceneAsync(this.battleSceneName2);
    }
}
