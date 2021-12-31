using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSceneController : MonoBehaviour
{
    // Boo singletons bad
    public static ShipSceneController Instance;

    [SerializeField]
    public List<ShipPart> initialParts;

    private Ship shipModel;
    private BuilderShipController builderShipController;
    private FighterShipController fighterShipController;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        builderShipController = GetComponentInChildren<BuilderShipController>();
        fighterShipController = GetComponentInChildren<FighterShipController>();

        shipModel = new Ship(new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT]);
        builderShipController.ResetToShipModel(shipModel);

        for (int i = 0; i < initialParts.Count; i++)
        {
            var item = initialParts[i];
            var go = builderShipController.ShipPartToGameObject(
                item,
                new Vector3(1f + (((float)i) * 1.5f), 0f)
            );
        }

    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void WriteShipModelToFighter()
    {
        //builderShipController.InitializeFromShipModel(shipModel);
        shipModel = builderShipController.BuildShipModel();
        //fighterShipController.ResetToShipModel(shipModel);

        //GetComponentInChildren<Projectile>().LaunchSelfAt(fighterShipController.transform.position);
        //fighterShipController.StartFight();
        GameController.Instance.GoToFightMode(shipModel);
    }

    public void WriteShipModelToBuilder()
    {
        shipModel = fighterShipController.BuildShipModel();
        builderShipController.ResetToShipModel(shipModel);
    }
}

/**
 * 
 * public void SaveAndWriteShipModelToFighter()
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
 */