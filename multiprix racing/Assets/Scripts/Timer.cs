using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    float time = 30f;
    float waitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Time Remaining: " + time;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime > 480)
        {
            time--;
            text.text = "Time Remaining: " + time;
            waitTime = 0;
        }
        else
        {
            waitTime++;
        }
        if(time == 0)
        {
            SceneManager.LoadScene("india_race");
        }
    }
}
