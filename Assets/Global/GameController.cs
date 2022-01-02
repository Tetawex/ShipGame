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
    private static string GAME_OVER_NAME = "GameOver";
    private static string BUILD_SCENE_NAME = "BuildMode";
    private static string FIGHT_SCENE_NAME = "FightMode";

    private string currentScene = "";

    public GameState currentState;

    public Ship CurrentShip = new Ship(new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT]);

    private List<ShipPart> rewardParts = new List<ShipPart>() { };

    public List<ShipPart> DefaultParts;

    private ShipGenerator shipGenerator;

    [SerializeField]
    private MusicPlayer musicPlayer;

    private int powerLevel = 0;
    private bool isLoading = false;

    private void Start()
    {
        GoToMainMenu();
    }
    public void GoToMainMenu()
    {
        LoadScene(MAIN_MENU_NAME);
    }

    public void GoToGameOver()
    {
        LoadScene(GAME_OVER_NAME);
    }

    public void GoToBuildModeInitial()
    {
        CurrentShip = new Ship(new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT]);
        //CurrentShip = shipGenerator.CreateShip(20);
        powerLevel = 0;
        rewardParts = new List<ShipPart>();
        rewardParts.AddRange(DefaultParts);

        rewardParts.Add(shipGenerator.GetRandomEngine());
        rewardParts.Add(Random.Range(0, 2) == 1 ? shipGenerator.GetRandomTurret() : shipGenerator.GetRandomRam());

        LoadScene(BUILD_SCENE_NAME);
    }

    public void GoToBuildModeWithReward(Ship enemyShip)
    {
        var allParts = new List<ShipPart>();
        for (int x = 0; x < ShipConstants.SHIP_GRID_WIDTH; x++)
        {
            for (int y = 0; y < ShipConstants.SHIP_GRID_HEIGHT; y++)
            {
                if (enemyShip.ShipParts[x, y] != null && !enemyShip.ShipParts[x, y].IsCockpit)
                {
                    allParts.Add(enemyShip.ShipParts[x, y]);
                }
            }
        }

        rewardParts = new List<ShipPart>();

        rewardParts.Add(ShipGenerator.PickRandom(allParts));
        if (Random.Range(0, 2) == 1)
        {
            rewardParts.Add(ShipGenerator.PickRandom(allParts));

        }
        if (Random.Range(0, 6) == 1)
        {
            rewardParts.Add(ShipGenerator.PickRandom(allParts));
        }
        LoadScene(BUILD_SCENE_NAME);
    }

    public void GoToFightMode(Ship? builtPlayerShip)
    {
        CurrentShip = builtPlayerShip ?? CurrentShip;

        LoadScene(FIGHT_SCENE_NAME);
    }

    private void LoadScene(string sceneName)
    {
        if (isLoading)
        {
            return;
        }
        isLoading = true;

        if (currentScene != "")
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        currentScene = sceneName;

        musicPlayer.PlayClip((sceneName == FIGHT_SCENE_NAME || sceneName == BUILD_SCENE_NAME) ? musicPlayer.BattleTheme : musicPlayer.MainMenuTheme);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLoading = false;
        if (scene.name.Contains(FIGHT_SCENE_NAME))
        {
            powerLevel++;
            FindObjectsOfType<FightSceneController>()[0].StartFight(CurrentShip, shipGenerator.CreateShip(powerLevel), powerLevel);
        }
        else if (scene.name.Contains(BUILD_SCENE_NAME))
        {
            FindObjectsOfType<BuildSceneController>()[0].StartBuilding(CurrentShip, rewardParts);
        }
        else if (scene.name.Contains(GAME_OVER_NAME))
        {
            FindObjectsOfType<GameOverController>()[0].DisplayGameOver(powerLevel);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        shipGenerator = GetComponentInChildren<ShipGenerator>();
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
