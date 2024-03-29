using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    float accel;
    float deccelrate = .1f;
    float maxSpeed;
    float velocity;
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
    CarType car;
    
    public TMP_Text text, scoreText, questionsText, placementText;
  
    // Start is called before the first frame update
    void Start()
    {
       accel = PlayerPrefs.GetFloat("acceleration");
       maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
       velocity = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        UnityEngine.Debug.Log(velocity);
        difficulty = PlayerPrefs.GetFloat("difficultymult");
        destroyrate = PlayerPrefs.GetFloat("destroyrate");
>>>>>>> Stashed changes
        
        Debug.Log(accel);
        Debug.Log(velocity);
        if (velocity < maxSpeed - 1)
        {
            text.text = "" + (int)velocity + " mph";
            
        }
        else{
            text.text = "" + (int)velocity + " mph" + "\n" + "(MAX SPEED!)";
        }
<<<<<<< Updated upstream
        if (delayStart > 180)
=======
        if (delayStart > 50)
>>>>>>> Stashed changes
        {
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 0 && !endGame && PlayerPrefs.GetInt("IsPaused") == 0)
            {
<<<<<<< Updated upstream
                velocity -= accel;
=======

               velocity -= (accel * difficulty) * 2;


>>>>>>> Stashed changes
            }
            if (endGame)
            {
                
                if (velocity > 0)
                {
                    velocity -= deccelrate;
                }
                else
                {
                    velocity = 0;
                    deccelrate = 0;
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
            questionsAnsweredRight = 0;
            questionsAnsweredWrong = 0;
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
            if (delayChange > 100)
            {
                if(PlayerPrefs.GetInt("phase") == 0){
                    
                SceneManager.LoadScene("Upgrades");
                }
                if(PlayerPrefs.GetInt("phase") == 1){
                    
                SceneManager.LoadScene("Game End");
                }
            }
            else
            {
                delayChange++;
            }


        }
    }

    enum CarType
    {
        Bluegatti,
        Redrari,
        Lamborgreeni,
        Whiteyota,
        Black_MW,
        Pinksla
    }


    public void setVelocity(float v)
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
        Debug.Log(points);
        PlayerPrefs.SetInt("currency", points);
    }



}
