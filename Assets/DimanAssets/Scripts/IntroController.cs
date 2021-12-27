using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject Dialogue;
    private DialogueController dialogController;
    // Start is called before the first frame update
    void Start()
    {
        dialogController = Dialogue?.GetComponent<DialogueController>();

        dialogController.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
