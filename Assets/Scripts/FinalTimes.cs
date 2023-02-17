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
        
    }

    // Update is called once per frame
    void Update()
    {
        birdfinal.text = "You survived " + BirdMovement.minutesfinal + ":" + BirdMovement.secondsfinal + " as the chicken.";
        chickenfinal.text = "You Survived" +  ChickenMovement.endtimechicken + " Seconds"; 
    }
}
