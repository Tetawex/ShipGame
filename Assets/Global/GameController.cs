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
    private static string BUILD_SCENE_NAME = "Scenes/BuildMode";

    public GameState currentState;

    public static Ship CurrentShip = null;

    public void GoToBuildMode()
    {
        currentState = GameState.BUILD_MODE;
        SceneManager.LoadSceneAsync(BUILD_SCENE_NAME, LoadSceneMode.Additive);
    }

    public void GoToMainMenu()
    {
        currentState = GameState.BUILD_MODE;
        SceneManager.UnloadSceneAsync(BUILD_SCENE_NAME);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GoToBuildMode();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Instance = null;
    }
}
