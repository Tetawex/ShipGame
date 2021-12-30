using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject Dialogue;
    private DialogueController dialogController;
    // Start is called before the first frame update
    private void Start()
    {
        dialogController = Dialogue?.GetComponent<DialogueController>();
        dialogController.OnDialogueOptionSelected += OnDialogueOptionSelected;
        dialogController.StartDialogue();
    }

    private void OnDestroy()
    {
        dialogController.OnDialogueOptionSelected -= OnDialogueOptionSelected;
    }

    private void OnDialogueOptionSelected(DialogueOptionSelectedPayload payload)
    {
        if (payload.ResponseOptionId == ResponseOptionId.BAD)
        {
            Debug.Log("Some BAD Logic");
        }
        else if (payload.ResponseOptionId == ResponseOptionId.GOOD)
        {
            Debug.Log("Some GOOD Logic");
        }
        else if (payload.ResponseOptionId == ResponseOptionId.RANDOM)
        {
            Debug.Log("Some RANDOM Logic");
        }
    }
}
