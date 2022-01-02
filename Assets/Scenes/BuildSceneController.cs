using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSceneController : MonoBehaviour
{
    [SerializeField]
    private BuilderShipController builderShipController;

    public void StartBuilding(Ship ship, List<ShipPart> rewardParts)
    {
        builderShipController.ResetToShipModel(ship);

        for (int i = 0; i < rewardParts.Count; i++)
        {
            var item = rewardParts[i];
            var go = builderShipController.ShipPartToGameObject(
                item,
                new Vector3(6.5f, 2f - (((float)i) * 1.5f))
            );
        }
    }

    public void OnPlayPress()
    {
        //try
        //{
            var ship = builderShipController.BuildShipModel();
            GameController.Instance.GoToFightMode(ship);
        //}
        //catch (Exception)
        //{
            //todo
        //}
    }
}
