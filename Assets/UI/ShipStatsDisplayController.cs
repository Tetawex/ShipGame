using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatsDisplayController : MonoBehaviour
{
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

    public void DisplayShipStats(IBaseShipStats shipStats)
    {
        hpText.text = "HP: " + shipStats.HP;

        shotADText.text = "AD: " + shipStats.ShotAD;
        shotASText.text = "AS: " + shipStats.ShotAS;

        ramADText.text = "AD: " + shipStats.RamAD;
        ramASText.text = "AS: " + shipStats.RamAS;
    }

    public void DisplayHP(float hp)
    {
        hpText.text = "HP: " + hp;
    }
}
