using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderShipController : MonoBehaviour
{
    //[SerializeField]
    //public int Width = 5;
    //[SerializeField]
    //public int Height = 3;

    [SerializeField]
    public GameObject slotPrefab;

    [SerializeField]
    public float SlotSize = 1f;

    [SerializeField]
    public GameObject shipPartWrapperPrefab;

    public GameObject shipInstance;
    void Start()
    {
        for (int x = 0; x < ShipConstants.SHIP_GRID_WIDTH; x++)
        {
            for (int y = 0; y < ShipConstants.SHIP_GRID_HEIGHT; y++)
            {
                Instantiate(
                    slotPrefab,
                    transform.position + new Vector3(
                        //0.5f * SlotSize +
                        x * SlotSize,
                        //-0.5f * SlotSize +
                        -y * SlotSize,
                        1f
                    ),
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    public void InitializeFromShipModel(Ship shipModel)
    {
        foreach (var part in GetComponentsInChildren<BuilderPart>())
        {
            Destroy(part.gameObject);
        }

        for (int x = 0; x < ShipConstants.SHIP_GRID_WIDTH; x++)
        {
            for (int y = 0; y < ShipConstants.SHIP_GRID_HEIGHT; y++)
            {
                var part = shipModel.ShipParts[x, y].ToBuilderPart(gameObject);
                part.transform.position = new Vector2(
                    x * ShipConstants.SHIP_PART_SIZE,
                    y * ShipConstants.SHIP_PART_SIZE
                );
            }
        }

        var shipParts = shipModel.GetComponentsInChildren<ShipPartHolder>();
        foreach (var shipPart in shipParts)
        {
            var instance = Instantiate(shipPartWrapperPrefab, transform.position, Quaternion.identity, transform);
            instance.GetComponent<BuilderPart>().AttachShipPartPrefab(shipPart.gameObject);
        }
    }

    public Ship BuildShipModel()
    {
        var partsArray = new ShipPart[Width, Height];
        foreach (var slot in GetComponentsInChildren<DraggableSlot>())
        {
            var slotContents = slot.GetDraggable();
            if (slotContents != null)
            {
                var x = (int)slot.transform.localPosition.x;
                var y = (int)slot.transform.localPosition.y;

                partsArray[x, y] = slotContents.gameObject.GetComponent<ShipPartHolder>().ShipPart;
            }
        }

        return new Ship(partsArray);
    }

    void Update()
    {

    }
}
