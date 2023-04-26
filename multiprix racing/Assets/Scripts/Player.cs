using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    float accel = .01f;
    float velocity = 20;
    int delayStart = 0;
    bool endGame = false;
    bool raceEnd = false;
    // points and stuff
    int questionsAnsweredRight = 0;
    int questionsAnsweredWrong = 0;
    int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (delayStart > 180)
        {
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 3 && !endGame)
            {
                velocity -= accel;
            }
            if (endGame) // once the car is in the end zone
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

                if (velocity == 0) // car stopped
                {
                    raceEnd = true;
                    calculatePoints();
                }

                if (raceEnd)
                {
                    endGame = false;
                    raceEnd = false;
                }
                


            }
        }
        else
        {
            delayStart++;
        }

        if (transform.position.x > 920)
        {
            accel = .1f;
            endGame = true;
        }
        
    }

    // adds v to the current velocity
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

    // calculates the total amount of points to add to the player after the game ends
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
        Debug.Log("Points earned: " + points);
    }

}
