using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueShow : MonoBehaviour
{
    public Sentence dialogue;

    public void TriggerText ()
    {
        FindObjectOfType<DialogueController>().StartDialogue();
    }
}
