using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ship Parts/Default", order = 2)]
public class ShipPart : ScriptableObject, IShipPart
{
    [SerializeField]
    private float hp = 0f;
    [SerializeField]
    private float shotAD = 0f;
    [SerializeField]
    private float shotAS = 0f;
    [SerializeField]
    private float ramAD = 0f;
    [SerializeField]
    private float ramAS = 0f;

    [SerializeField]
    private string name = "";
    [SerializeField]
    private string description = "";

    public ShipPart() { }

    public float HP => hp;
    public float ShotAD => shotAD;
    public float ShotAS => shotAS;
    public float RamAD => ramAD;
    public float RamAS => ramAS;

    public string Name => name;
    public string Description => description;
}

/*
public ShipPart(float hp, float shotAD, float shotAS, float ramAD, float ramAS, string description)
{
    this.hp = hp;
    this.shotAD = shotAD;
    this.shotAS = shotAS;
    this.ramAD = ramAD;
    this.ramAS = ramAS;
    this.description = description;
}*/