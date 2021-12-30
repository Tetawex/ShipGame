using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text Response1;
    public Text Response2;
    public Text Response3;
    public List<Text> ResponseBoxes;
    

    private Queue<Sentence> currentSentences;

    [SerializeField]
    public SentenceData SentenceData;

    private void Start()
    {
        ResponseBoxes.Add(Response1);
        ResponseBoxes.Add(Response2);
        ResponseBoxes.Add(Response3);
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
            return;
        }

        var thisSentence = currentSentences.Dequeue();

        DisplayResponse(thisSentence.Responses);

        DisplaySentence(thisSentence);
    }

    public void DisplaySentence(Sentence sentence)
    {
        nameText.text = sentence.Name;
        dialogueText.text = sentence.Text;
    }

    public void DisplayResponse(List<Response> responses)
    {
        foreach (var textbox in ResponseBoxes)
        {
            textbox.text = "";
        }

        if (responses != null)
        {
            // Will break if more than 3 responses
            for (int i = 0; i < responses.Count; i++)
            {
                ResponseBoxes[i].text = responses[i].Text;
            }
        }
    }
}
