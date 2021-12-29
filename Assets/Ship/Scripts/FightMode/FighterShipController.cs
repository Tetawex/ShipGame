using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShipController : GenericShipController
{
    public Ship Ship;
    public IBaseShipStats ShipStats;
    public float ShipCurrentHP = 0f;
    void Start()
    {
        GetComponentInChildren<ProjectileReceiver>().OnProjectileReceived += HandleProjectileReceived;
    }

    public void StartFight()
    {
        Ship = BuildShipModel();
        ShipStats = Ship.GetShipStats();
        ShipCurrentHP = ShipStats.HP;
    }

     public void HandleProjectileReceived(Projectile projectile) {
        ShipCurrentHP -= 10f;
    }

    public override GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        var instance = part.ToGameObject(gameObject);
        instance.transform.localPosition = position;

        return instance;
    }
}
