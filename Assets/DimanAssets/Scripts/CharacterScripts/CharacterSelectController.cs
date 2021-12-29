using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField]
    public List<CharacterData> CharacterDatas;

    public GameObject PilotDisplay;

    [SerializeField]
    public GameObject AbilityDescription;

    private int CurrentCharacterIndex = 0;

    void Start()
    {
        DisplayAtIndex(CurrentCharacterIndex);
    }   

    public void DisplayData(CharacterData data)
    {
        PilotDisplay.GetComponent<SpriteRenderer>().sprite = data.Sprite;
    }

    public void AbilityText(CharacterData data)
    {
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
        AbilityText(CharacterDatas[CurrentCharacterIndex]);
    }

    public void DisplayNext()
    {
        DisplayAtIndex(CurrentCharacterIndex + 1);
        AbilityText(CharacterDatas[CurrentCharacterIndex]);
    }

    public void DisplayPrevious()
    {
        DisplayAtIndex(CurrentCharacterIndex - 1);
        AbilityText(CharacterDatas[CurrentCharacterIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*characterPosition = Pilot1.transform.position;
        characterOutside = Pilot3.transform.position;

        Pilot1Render = Pilot1.GetComponent<SpriteRenderer>();
        Pilot2Render = Pilot2.GetComponent<SpriteRenderer>();
        Pilot3Render = Pilot3.GetComponent<SpriteRenderer>();
    }

    public void Next()
    {
        switch (CharacterId)
        {
            case 1:
                Pilot1Render.enabled = false;
                Pilot1.transform.position = characterOutside;

                Pilot2.transform.position = characterPosition;
                Pilot2Render.enabled = true;

                CharacterId++;
                break;
            case 2:
                Pilot2Render.enabled = false;
                Pilot2.transform.position = characterOutside;

                Pilot3.transform.position = characterPosition;
                Pilot3Render.enabled = true;

                CharacterId++;
                break;
            case 3:
                Pilot3Render.enabled = false;
                Pilot3.transform.position = characterOutside;

                Pilot1.transform.position = characterPosition;
                Pilot1Render.enabled = true;

                CharacterId++;
                Loop(); 
                break;
            default:
                Loop();
                break;
        }
    } 

 private int CharacterId = 1;

    private SpriteRenderer Pilot1Render, Pilot2Render, Pilot3Render;

    private Vector3 characterPosition;
    private Vector3 characterOutside;

 public void Previous()
    {
        switch (CharacterId)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    private void Loop()
    {
        if (CharacterId >= 3) CharacterId = 1;
        else if (CharacterId <= 0) CharacterId = 3; 
    }*/
