using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Sentences", order = 1)]
public class SentenceData :ScriptableObject
{
    [SerializeField]
    public List<Sentence> Sentences;
}
