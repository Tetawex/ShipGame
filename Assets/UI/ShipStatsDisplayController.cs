using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatsDisplayController : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Text shotADText;
    [SerializeField]
    private Text shotASText;
    [SerializeField]
    private Text ramADText;
    [SerializeField]
    private Text ramASText;

    public void Awake()
    {
        hpText.text = "HP: " + 0;

        shotADText.text = "Dmg: " + 0;
        shotASText.text = "Speed: " + 0;

        ramADText.text = "Dmg: " + 0;
        ramASText.text = "Speed: " + 0;
    }

    public void DisplayShipStats(IBaseShipStats shipStats)
    {
        hpText.text = "HP: " + shipStats.HP.ToString("0.#");

        shotADText.text = "Dmg: " + shipStats.ShotAD.ToString("0.#");
        shotASText.text = "Speed: " + shipStats.ShotAS.ToString("0.#");

        ramADText.text = "Dmg: " + shipStats.RamAD.ToString("0.#");
        ramASText.text = "Speed: " + shipStats.RamAS.ToString("0.#");
    }

    public void DisplayName(string name)
    {
        nameText.text = name;
    }

    public void DisplayHP(float hp)
    {
        hpText.text = "HP: " + (hp > 0 ? hp.ToString() : "RIP");
    }
}
