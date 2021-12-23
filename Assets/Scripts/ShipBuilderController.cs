using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBuilderController : MonoBehaviour
{
    [SerializeField]
    public Vector2 GridDimensions = new Vector2(3, 5);

    [SerializeField]
    public GameObject slotPrefab;

    [SerializeField]
    public float SlotSize = 1f;


    void Start()
    {
        for (int x = 0; x < GridDimensions.x; x++)
        {
            for (int y = 0; y < GridDimensions.y; y--)
            {
                Instantiate(slotPrefab, new Vector3(0.5f * SlotSize, -0.5f * SlotSize) + new Vector3(x * SlotSize, y * SlotSize, transform.position.z), Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {

    }
}
