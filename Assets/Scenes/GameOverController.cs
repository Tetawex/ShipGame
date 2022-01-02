using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public void DisplayGameOver(int powerLevel)
    {
        text.text = "Game over\nYou've reached level " + powerLevel;
    }
    public void OnStartPress()
    {
        GameController.Instance.GoToBuildModeInitial();
    }
}
