using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipStatsInstance : IBaseShipStats
{
    private float hp = 0f;
    private float shotAD = 0f;
    private float shotAS = 0f;
    private float ramAD = 0f;
    private float ramAS = 0f;

    public ShipStatsInstance(float hp, float shotAD, float shotAS, float ramAD, float ramAS)
    {
        this.hp = hp;
        this.shotAD = shotAD;
        this.shotAS = shotAS;
        this.ramAD = ramAD;
        this.ramAS = ramAS;
    }

    public float HP => hp;

    public float ShotAD => shotAD;

    public float ShotAS => shotAS;

    public float RamAD => ramAD;

    public float RamAS => ramAS;
}
public class Ship
{
    // TODO 2x2 matrix for deeper part interaction
    public ShipPart[,] ShipParts;

    public Ship(ShipPart[,] shipParts)
    {
        this.ShipParts = shipParts;
    }

    public IBaseShipStats GetShipStats()
    {
        float totalHp = 0f;
        float totalShotAD = 0f;
        float totalShotAS = 0f;
        float totalRamAD = 0f;
        float totalRamAS = 0f;

        for (int x = 0; x < ShipParts.GetLength(0); x++)
        {
            for (int y = 0; y < ShipParts.GetLength(1); y++)
            {
                if (ShipParts[x, y] == null)
                {
                    continue;
                }
                totalHp += ShipParts[x, y].HP;
                totalRamAD += ShipParts[x, y].RamAD;
                totalRamAS += ShipParts[x, y].RamAS;
                totalShotAD += ShipParts[x, y].ShotAD;
                totalShotAS += ShipParts[x, y].ShotAS;
            }
        }

        totalHp = totalHp < 0 ? 0f : totalHp;
        totalShotAD = totalShotAD < 0 ? 0f : totalShotAD;
        totalShotAS = totalShotAS < 0 ? 0f : totalShotAS;
        totalRamAD = totalRamAD < 0 ? 0f : totalRamAD;
        totalRamAS = totalRamAS < 0 ? 0f : totalRamAS;

        return new ShipStatsInstance(totalHp, totalShotAD, totalShotAS, totalRamAD, totalRamAS);
    }
}

/*
 *     float IBaseShipStats.HP
    {
        get
        {
            float totalHp = 0f;

            for (int x = 0; x < shipParts.GetLength(0); x++)
            {
                for (int y = 0; y < shipParts.GetLength(1); y++)
                {
                    totalHp += shipParts[x, y].HP;
                }
            }
            return totalHp;
        }
    }

     float IBaseShipStats.HP => shipParts
        .Select(part => part.HP)
        .Aggregate((sum, part) => sum + part);

    float IBaseShipStats.ShotAD => shipParts
        .Select(part => part.ShotAD)
        .Aggregate((sum, part) => sum + part);

    float IBaseShipStats.ShotAS => shipParts
        .Select(part => part.ShotAS)
        .Aggregate((sum, part) => sum + part);

    float IBaseShipStats.RamAD => shipParts
        .Select(part => part.RamAD)
        .Aggregate((sum, part) => sum + part);

    float IBaseShipStats.RamAS => shipParts
        .Select(part => part.RamAS)
        .Aggregate((sum, part) => sum + part);
}

 */