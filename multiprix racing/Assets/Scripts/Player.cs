using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    float accel = .01f;
    float velocity = 20;
    int delayStart = 0;
    bool endGame = false;
    int questionsAnsweredRight = 0;
    int questionsAnsweredWrong = 0;
    public TMP_Text text;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (int)velocity + " mph";
        if (delayStart > 180)
        {
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 3 && !endGame)
            {
                velocity -= accel;
            }
            if (endGame)
            {
                
                if (velocity > 0)
                {
                    velocity -= accel;
                }
                else
                {
                    velocity = 0;
                    accel = 0;
                }
                // fix this infinitely looping
                Debug.Log("Questions Answered: " + questionsAnsweredRight + "/" + (questionsAnsweredRight + questionsAnsweredWrong));
                Debug.Log("Percent Accuracy: " + ( 100 * (double)questionsAnsweredRight) / (questionsAnsweredRight + questionsAnsweredWrong));
                
            }
        }
        else
        {
            delayStart++;
        }

        if (transform.position.x > 900)
        {
            accel = .1f;
            endGame = true;
        }
        
    }
   
    public void setVelocity(int v)
    {
        if (velocity < 30)
        {
            velocity += v;
        }
    }

    public bool getEndGame()
    {
        return endGame;
    }

    // adds a number to the total tally of correct answers
    public void setQuestionsAnswered(bool right)
    {
        if (right)
        {
            questionsAnsweredRight++;
        }
        else
        {
            questionsAnsweredWrong++;
        }
       
    }
    

}
