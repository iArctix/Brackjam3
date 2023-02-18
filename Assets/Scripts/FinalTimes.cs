using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTimes : MonoBehaviour
{

    public TMPro.TextMeshProUGUI birdfinal;
    public TMPro.TextMeshProUGUI chickenfinal;
    // Start is called before the first frame update
    void Start()
    {
        birdfinal.text = "Bird = " + BirdController.finalTime;
        chickenfinal.text = "You Survived" + ChickenMovement.endtimechicken + " Seconds";
    }
}
