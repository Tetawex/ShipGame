using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    public Sentence dialogue;

    public void TriggerText ()
    {
        FindObjectOfType<TextController>().StartDialogue();
    }
}
