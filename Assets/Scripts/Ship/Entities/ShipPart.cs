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

    [SerializeField]
    public GameObject Prefab;

    public ShipPart() { }

    public float HP => hp;
    public float ShotAD => shotAD;
    public float ShotAS => shotAS;
    public float RamAD => ramAD;
    public float RamAS => ramAS;

    public string Name => name;
    public string Description => description;


    public GameObject ToModelPart(GameObject parent)
    {
        var instance = Instantiate(
            Prefab,
            parent.transform.position + Prefab.transform.position,
            Quaternion.identity,
            parent.transform);

        var shipPartHolder = instance.AddComponent<ShipPartHolder>();
        shipPartHolder.ShipPart = this;

        return instance;
    }
    public GameObject ToBuilderPart(GameObject parent)
    {
        var instance = ToModelPart(parent);

        instance.AddComponent<Draggable>();
        instance.AddComponent<BuilderPart>();
        instance.AddComponent<BoxCollider2D>();

        return instance;
    }
    public GameObject ToFighterPart(GameObject parent)
    {
        var instance = ToModelPart(parent);
        return instance;
    }
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