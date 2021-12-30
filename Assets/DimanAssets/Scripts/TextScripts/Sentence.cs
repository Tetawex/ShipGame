using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
    public string Name;

    [TextArea(3, 10)]
    public string Text;

    public List<Response> Responses;
}