using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<Sentence> currentSentences;

    [SerializeField]
    public SentenceData SentenceData;

    private void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        currentSentences = new Queue<Sentence>(SentenceData.Sentences);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {

    }

    public void DisplayNextSentence()
    {
        if (currentSentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DisplaySentence(currentSentences.Dequeue());
    }

    public void DisplaySentence(Sentence sentence)
    {
        nameText.text = sentence.Name;
        dialogueText.text = sentence.Text;
    }
}
