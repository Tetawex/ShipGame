using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField]
    public List<CharacterData> CharacterDatas;

    public Vector3 PositionStart = GameObject.Find("StartPosition").transform.position;

    void Start()
    {
        foreach (var pilot in CharacterDatas)
        {
            //Instantiate(pilot, PositionStart);
        }

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
