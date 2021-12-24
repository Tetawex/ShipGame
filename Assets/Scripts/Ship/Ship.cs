using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : IBaseShipStats
{
    // TODO 2x2 matrix for deeper part interaction
    private IEnumerable<IShipPart> shipParts;

    public Ship(IEnumerable<IShipPart> shipParts)
    {
        this.shipParts = shipParts;
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
