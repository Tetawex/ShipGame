using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum ResponseOptionId
{
    GOOD, BAD, RANDOM
}

[System.Serializable]
public class Response
{
    public ResponseOptionId Id;
    public string Text;
}
