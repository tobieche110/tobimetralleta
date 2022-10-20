using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    private float currentTime;
    private float lastTime;
    public TMP_Text timerText;

    private void Start() {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - lastTime;
        timerText.text = "Timer: "+currentTime.ToString("F2");
    }
}
