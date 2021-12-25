using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightShipController : MonoBehaviour
{
    [SerializeField]
    public GameObject shipPartWrapperPrefab;

    void Start()
    {

    }
    void Update()
    {

    }

    public void InitializeFromShipModel(GameObject shipModel)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        var shipParts = shipModel.GetComponentsInChildren<ShipPartHolder>();
        foreach (var shipPart in shipParts)
        {
            var instance = Instantiate(shipPartWrapperPrefab, transform.position, Quaternion.identity, transform);
            instance.GetComponent<FightPart>().AttachShipPartPrefab(shipPart.gameObject);
        }
    }


}
