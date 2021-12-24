using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBuilderController : MonoBehaviour
{
    [SerializeField]
    public int Width = 5;
    [SerializeField]
    public int Height = 3;

    [SerializeField]
    public GameObject slotPrefab;

    [SerializeField]
    public float SlotSize = 1f;


    void Start()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y <Height; y++)
            {
                Instantiate(
                    slotPrefab,
                    transform.position + new Vector3(
                        0.5f * SlotSize + x * SlotSize,
                        -0.5f * SlotSize - y * SlotSize,
                        1f
                    ),
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    void Update()
    {

    }
}
