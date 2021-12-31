using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamAnimationEventReceiver : MonoBehaviour
{
    private FighterShipController fighterShipController;
    void Start()
    {
        fighterShipController = GetComponentInChildren<FighterShipController>();
    }

    public void OnRamAnimationEnd()
    {
        fighterShipController.OnRamAnimationEnd();
    }
}
