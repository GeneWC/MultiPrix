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
    string[] mapnames = { "africa_race", "america_race", "china_race", "Mazda" };
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Time Remaining: " + time;
        randomNumber = Random.Range(0, 2);
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(waitTime > 520)
=======
        
        if (waitTime > 35)
>>>>>>> Stashed changes
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
            
            SceneManager.LoadScene(mapnames[randomNumber]);
        }
    }
}
