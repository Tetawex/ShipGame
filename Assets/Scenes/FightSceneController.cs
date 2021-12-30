using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneController : MonoBehaviour
{
    public GameObject playerShipGO;
    public GameObject enemyShipGO;

    private FighterShipController playerShipController;
    private FighterShipController enemyShipController;
    public void StartFight(Ship playerShip, Ship enemyShip)
    {
        playerShipController.ResetToShipModel(playerShip);
        enemyShipController.ResetToShipModel(enemyShip);

        playerShipController.StartFight(enemyShipGO, TeamTag.PLAYER);
        enemyShipController.StartFight(playerShipGO, TeamTag.ENEMY);

        enemyShipGO.transform.localScale = new Vector3(-enemyShipGO.transform.localScale.x, enemyShipGO.transform.localScale.y, enemyShipGO.transform.localScale.z);
    }

    void Awake()
    {
        playerShipController = playerShipGO.GetComponent<FighterShipController>();
        enemyShipController = enemyShipGO.GetComponent<FighterShipController>();
    }

    void Update()
    {

    }
}
