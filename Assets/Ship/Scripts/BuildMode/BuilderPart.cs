using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderPart : MonoBehaviour
{
    private GameObject? shipPartGameObject;
    // Start is called before the first frame update
    void Start()
    {
        // shipPartGameObject = GetComponentInChildren<ShipPartHolder>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject AttachShipPartPrefab(GameObject prefab)
    {
        var instance = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        instance.AddComponent<BuilderPart>();
        instance.AddComponent<Draggable>();
        instance.AddComponent<BoxCollider2D>();
        instance.SetActive(true);

        shipPartGameObject = instance;

        transform.position = transform.parent.position +
            new Vector3(prefab.transform.position.x, prefab.transform.position.y);

        return instance;
    }
}
