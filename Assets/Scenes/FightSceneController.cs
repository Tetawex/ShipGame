using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSceneController : MonoBehaviour
{
    public GameObject playerShipGO;
    public GameObject enemyShipGO;

    public Text levelDisplayText;

    private FighterShipController playerShipController;
    private FighterShipController enemyShipController;
    public void StartFight(Ship playerShip, Ship enemyShip, int powerLevel)
    {
        playerShipController.ResetToShipModel(playerShip);
        enemyShipController.ResetToShipModel(enemyShip);

        playerShipController.StartFight(enemyShipGO, TeamTag.PLAYER);
        enemyShipController.StartFight(playerShipGO, TeamTag.ENEMY);

        enemyShipGO.transform.localScale = new Vector3(-enemyShipGO.transform.localScale.x, enemyShipGO.transform.localScale.y, enemyShipGO.transform.localScale.z);

        playerShipController.OnDidReceiveFatalDamage += OnPlayerDead;
        enemyShipController.OnDidReceiveFatalDamage += OnEnemyDead;

        levelDisplayText.text = "Level " + powerLevel;
    }

    void Awake()
    {
        playerShipController = playerShipGO.GetComponentInChildren<FighterShipController>();
        enemyShipController = enemyShipGO.GetComponentInChildren<FighterShipController>();
    }

    void Update()
    {

    }

    private void StopFight()
    {
        playerShipController.StopFight();
        enemyShipController.StopFight();
    }

    private void OnPlayerDead()
    {
        StopFight();

        Invoke("GoToGameOver", 0.3f);
    }

    private void OnEnemyDead()
    {
        StopFight();

        Invoke("GoToBuildModeWithReward", 0.3f);
    }

    private void GoToBuildModeWithReward()
    {
        GameController.Instance.GoToBuildModeWithReward(enemyShipController.Ship);
    }

    private void GoToGameOver()
    {
        GameController.Instance.GoToGameOver();
    }
}
