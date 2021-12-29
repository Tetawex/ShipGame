using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability
{
    MAN, WOMAN, NONBINARY
}

[CreateAssetMenu(fileName = "Data", menuName = "Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public int Id;
    public Sprite Sprite;
    public string Name;
    public Ability Ability;
}

