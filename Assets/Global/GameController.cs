using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MAIN_MENU, BUILD_MODE, FIGHT_MODE
}

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private static string MAIN_MENU_NAME = "MainMenu";
    private static string BUILD_SCENE_NAME = "BuildMode";
    private static string FIGHT_SCENE_NAME = "FightMode";

    private string currentScene = "";

    public GameState currentState;

    public Ship CurrentShip = null;

    private List<ShipPart> rewardParts;

    public void GoToMainMenu()
    {
        LoadScene(MAIN_MENU_NAME);
    }

    public void GoToBuildModeInitial()
    {
        this.rewardParts = new List<ShipPart>();
        LoadScene(BUILD_SCENE_NAME);
    }

    public void GoToBuildModeWithReward(List<ShipPart> rewardParts)
    {
        this.rewardParts = rewardParts;
        LoadScene(BUILD_SCENE_NAME);
    }

    public void GoToFightMode(Ship? builtPlayerShip)
    {
        CurrentShip = builtPlayerShip ?? CurrentShip;

        LoadScene(FIGHT_SCENE_NAME);
    }

    private void LoadScene(string sceneName)
    {
        if (currentScene != "")
        {
            SceneManager.UnloadScene(currentScene);
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        currentScene = sceneName;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Contains(FIGHT_SCENE_NAME))
        {
            FindObjectsOfType<FightSceneController>()[0].StartFight(CurrentShip, CurrentShip);
        }
        else if (scene.name.Contains(BUILD_SCENE_NAME))
        {

        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        //GoToBuildMode();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Instance = null;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
