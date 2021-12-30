using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * AS - attacks per second
 * AD - damage of the attack
 */
public interface IBaseShipStats
{
    public float HP { get; }
    public float ShotAD { get; }
    public float ShotAS { get; }
    public float RamAD { get; }
    public float RamAS { get; }
}
