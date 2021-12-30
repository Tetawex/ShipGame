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

    public static Ship CurrentShip = null;

    public void GoToMainMenu()
    {
        currentState = GameState.BUILD_MODE;
        SceneManager.LoadScene(BUILD_SCENE_NAME, LoadSceneMode.Single);
    }

    public void GoToBuildMode()
    {
        currentState = GameState.BUILD_MODE;
        SceneManager.LoadScene(BUILD_SCENE_NAME, LoadSceneMode.Single);
    }

    public void GoToFightMode(Ship? builtPlayerShip)
    {
        CurrentShip = builtPlayerShip ?? CurrentShip;
        Debug.Log(builtPlayerShip);

        // currentState = GameState.BUILD_MODE;
        //CurrentShip =  FindObjectsOfType<BuilderShipController>()[0].BuildShipModel();

        if (currentScene != "")
        {
            SceneManager.UnloadScene(currentScene);
        }

        SceneManager.LoadScene(FIGHT_SCENE_NAME, LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Contains(FIGHT_SCENE_NAME))
        {
                    FindObjectsOfType<FightSceneController>()[0].StartFight(CurrentShip, CurrentShip);
        }
    }
}
