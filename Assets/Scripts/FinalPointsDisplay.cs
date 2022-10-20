using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalPointsDisplay : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Puntaje: "+johnMovement.finalPoints;
    }

}
