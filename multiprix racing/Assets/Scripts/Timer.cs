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
    float waitTime;
    int randomNumber;
    bool runningoutoftime;
   

    // Start is called before the first frame update
    void Start()
    {
        
        text.text = "Time Remaining: " + time;
        randomNumber = Random.Range(0, 2);
        waitTime = 0;
        runningoutoftime = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (waitTime > 480)
        {
            if(time < 11)
            {
                runningoutoftime = true;
            }
            if (runningoutoftime)
            {
                if(time % 2 == 0)
                {
                    text.color = new Color(255, 0, 0);
                }
                else
                {
                    text.color = new Color(255, 255, 255);
                }
            }
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
            PlayerPrefs.SetInt("mapnumber", PlayerPrefs.GetInt("mapnumber") + 1);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency"));
            SceneManager.LoadScene("Briefing");
        }
    }
}
