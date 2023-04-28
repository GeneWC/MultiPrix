using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float time = 25;
    public float waiting = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = transform.Find("Timeleft").GetComponent<TextMeshProUGUI>();
        timer.SetText("Time Remaining: " + time + " seconds");
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting > 600)
        {
            timer.SetText("Time Remaining: " + time + " seconds");
            time--;
            waiting = 0;
        }
        else { waiting++; }
    }
}