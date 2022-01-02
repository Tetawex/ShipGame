using System.Collections;
using UnityEngine;


public class GenericShipController : MonoBehaviour
{
    public virtual GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.identity);
    }

    public virtual void BeforeReset()
    {
    }

    public void ResetToShipModel(Ship shipModel)
    {
        foreach (var part in GetComponentsInChildren<ShipPartHolder>())
        {
            Destroy(part.gameObject);
        }

        BeforeReset();

        for (int x = 0; x < ShipConstants.SHIP_GRID_WIDTH; x++)
        {
            for (int y = 0; y < ShipConstants.SHIP_GRID_HEIGHT; y++)
            {
                var part = shipModel.ShipParts[x, y];
                if (part != null)
                {
                    var go = ShipPartToGameObject(part, new Vector3(
                        x * ShipConstants.SHIP_PART_SIZE,
                        y * ShipConstants.SHIP_PART_SIZE,
                        transform.position.z - 1f //hack
                    ));
                }
            }
        }
    }

    public Ship BuildShipModel()
    {
        var partsArray = new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT];
        foreach (var slot in GetComponentsInChildren<ShipPartHolder>())
        {
            if (slot != null)
            {
                var x = (int)(slot.transform.localPosition.x);
                var y = (int)(slot.transform.localPosition.y);
                if (x >= 0 && x < ShipConstants.SHIP_GRID_WIDTH && y >= 0 && y < ShipConstants.SHIP_GRID_HEIGHT)
                {
                    partsArray[x, y] = slot.gameObject.GetComponent<ShipPartHolder>().ShipPart;
                }
            }
        }

        return new Ship(partsArray);
    }
}
