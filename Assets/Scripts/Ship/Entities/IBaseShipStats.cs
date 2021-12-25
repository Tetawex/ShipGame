using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseShipStats
{
    public float HP { get; }
    public float ShotAD { get; }
    public float ShotAS { get; }
    public float RamAD { get; }
    public float RamAS { get; }
}
