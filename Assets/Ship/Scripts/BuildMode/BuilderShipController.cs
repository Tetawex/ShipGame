using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderShipController : GenericShipController
{
    public Draggable? draggableMutex = null;

    [SerializeField]
    public GameObject slotPrefab;

    [SerializeField]
    public float SlotSize = 1f;

    void Start()
    {
        //resetGrid();
    }

    public override void BeforeReset()
    {
        resetGrid();
    }

    private void resetGrid()
    {
        foreach(DraggableSlot slot in GetComponentsInChildren<DraggableSlot>())
        {
            Destroy(slot.gameObject);
        }
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
                        y * SlotSize,
                        1f
                    ),
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    public override GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        var instance = part.ToGameObject(gameObject);
        instance.transform.localPosition = position;

        var draggable = instance.AddComponent<Draggable>();
        instance.AddComponent<BuilderPart>();
        var boxCollider = instance.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(ShipConstants.SHIP_PART_SIZE, ShipConstants.SHIP_PART_SIZE);

        draggable.initialPosition = instance.transform.position;
        draggable.SetDragged(false);

        return instance;
    }
}
