using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    public TextOptions dialogue;

    public void TriggerText ()
    {
        FindObjectOfType<TextController>().StartDialogue(dialogue);
    }
}
