using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField]
    public List<CharacterData> CharacterDatas;

    public GameObject PilotDisplay;
    public GameObject AbilityDescription;

    private int CurrentCharacterIndex = 0;

    void Start()
    {
        DisplayAtIndex(CurrentCharacterIndex);
    }   

    public void DisplayData(CharacterData data)
    {
        PilotDisplay.GetComponent<SpriteRenderer>().sprite = data.Sprite;
        AbilityDescription.GetComponent<Text>().text = data.Ability.ToString();
    }

    public void DisplayAtIndex(int index)
    {
        CurrentCharacterIndex = index;

        if (CurrentCharacterIndex >= CharacterDatas.Count)
        {
            CurrentCharacterIndex = 0;
        }
        else if (CurrentCharacterIndex < 0)
        {
            CurrentCharacterIndex = CharacterDatas.Count - 1;
        }

        DisplayData(CharacterDatas[CurrentCharacterIndex]);
    }

    public void DisplayNext()
    {
        DisplayAtIndex(CurrentCharacterIndex + 1);
    }

    public void DisplayPrevious()
    {
        DisplayAtIndex(CurrentCharacterIndex - 1);
    }
}