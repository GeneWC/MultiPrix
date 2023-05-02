using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    float accel = .005f;
    float maxSpeed = 31;
    float velocity = 40;
    int delayStart = 0;
    int delayChange = 0;
    bool doneplaying = false;
    bool endGame = false;
    bool raceEnd = false;
    bool endGameAlreadyRan = false;
    // points and stuff
    int questionsAnsweredRight = 0;
    int questionsAnsweredWrong = 0;
    int points = 0;
    public TMP_Text text, scoreText, questionsText, placementText;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (velocity < maxSpeed - 1)
        {
            text.text = "" + (int)velocity + " mph";
            
        }
        else{
            text.text = "" + (int)velocity + " mph" + "\n" + "(MAX SPEED!)";
        }
        if (delayStart > 180)
        {
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 0 && !endGame)
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
                
                if (raceEnd)
                {
                    endGame = false;
                    raceEnd = false;
                }
                questionsText.text = "Questions Answered: " + questionsAnsweredRight + "/" + (questionsAnsweredRight + questionsAnsweredWrong);
                placementText.text = "You placed" + "1st!";
                Debug.Log("Percent Accuracy: " + ( 100 * (double)questionsAnsweredRight) / (questionsAnsweredRight + questionsAnsweredWrong));
                doneplaying = true;
                calculatePoints();
                    
                
                   
                }
            }
        
        else
        {
            delayStart++;
        }

        if (transform.position.x > 920 && !endGameAlreadyRan)
        {
            accel = .1f;
            endGame = true;
            endGameAlreadyRan = true;
            raceEnd = true;
            
        }
        if (doneplaying)
        {
            if (delayChange > 1440)
            {
                SceneManager.LoadScene("Upgrades");
            }
            else
            {
                delayChange++;
            }
        }
    }
   
    public void setVelocity(int v)
    {
        if (velocity < maxSpeed - v)
        {
            velocity += v;
            
        }
        else{
            velocity = maxSpeed;
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

    public void calculatePoints()
    {
        double percentAccuracy = Math.Round(100 * (double)(questionsAnsweredRight) / (questionsAnsweredRight + questionsAnsweredWrong), 2);
        Debug.Log("Questions Answered: " + questionsAnsweredRight + "/" + (questionsAnsweredRight + questionsAnsweredWrong));
        Debug.Log("Percent Accuracy: " + percentAccuracy);

        // award points for correct answers, take away points for incorrect answers
        points += (questionsAnsweredRight * 50);
        if (points - (questionsAnsweredWrong * 20) >= 0) // check if points will go into the negatives
        {
            points -= questionsAnsweredWrong * 20;
        }
        else // only executes if points will go into the negatives, set it equal to 0
        {
            points = 0;
        }

        // bonus points for accuracy
        if (questionsAnsweredRight + questionsAnsweredWrong < 10)
        {
            // give no bonus if too little questions answered
            Debug.Log("Not enough questions answered for accuracy bonus");
        }
        else if (percentAccuracy == 100.0d)
        {
            points += 200;
        }
        else if (percentAccuracy >= 95.0d)
        {
            points += 150;
        }
        else if (percentAccuracy >= 90.0d)
        {
            points += 100;
        }
        else if (percentAccuracy >= 70.0d)
        {
            points += 40;
        }

        // output num of points
        scoreText.text = ("Points earned: " + points);
    }



}
