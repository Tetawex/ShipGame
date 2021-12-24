using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipPart : IBaseShipStats
{
    public string Name { get; }
    public string Description { get; }
}
