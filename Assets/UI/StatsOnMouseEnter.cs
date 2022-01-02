using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsOnMouseEnter : MonoBehaviour
{
    private ShipStatsDisplayController shipStatsDisplayController;
    private ShipPartHolder shipPartHolder;
    void Start()
    {
        shipStatsDisplayController = FindObjectOfType<ShipStatsDisplayController>();
        shipPartHolder = GetComponent<ShipPartHolder>();
    }

    private void OnMouseEnter()
    {
        shipStatsDisplayController.DisplayShipStats(shipPartHolder.ShipPart);
        shipStatsDisplayController.DisplayName(shipPartHolder.ShipPart.Name + '\n' + shipPartHolder.ShipPart.Description);
    }
}
