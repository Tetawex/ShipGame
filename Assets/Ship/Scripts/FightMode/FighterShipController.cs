using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShipController : GenericShipController
{
    void Start()
    {

    }

    public override GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        var instance = part.ToGameObject(gameObject);
        instance.transform.localPosition = position;

        return instance;
    }
}
