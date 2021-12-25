using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSceneController : MonoBehaviour
{
    // Boo singletons bad
    public static ShipSceneController Instance;

    private ShipModel shipModel;
    private BuilderShipController builderShipController;
    private FightShipController fightShipController;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        builderShipController = GetComponentInChildren<BuilderShipController>();
        fightShipController = GetComponentInChildren<FightShipController>();

        shipModel = GetComponentInChildren<ShipModel>();
        shipModel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void WriteShipModelToBuilder()
    {
        builderShipController.InitializeFromShipModel(shipModel.gameObject);
    }

    public void SaveAndWriteShipModelToFighter()
    {
        var builderController = GetComponentInChildren<BuilderShipController>();

        // Clearing the ship model
        foreach (Transform child in shipModel.gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        // Copying the builder model to the ship model
        foreach (Transform shipPartWrapperTransform in builderController.transform)
        {
            var shipPart =  shipPartWrapperTransform
                    .gameObject
                    ?.GetComponentInChildren<ShipPartHolder>()
                    ?.gameObject;

            var shipPartCopy = Instantiate(
                shipPart,
                shipPartWrapperTransform.transform.position,
                Quaternion.identity,
                shipModel.gameObject.transform
            );
        }

        fightShipController.InitializeFromShipModel(shipModel.gameObject);
    }
}
