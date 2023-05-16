using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    
    float accel;
    float deccelrate = 10f;
    float maxSpeed;
    float velocity;
    int delayStart = 0;
    int delayChange = 0;
    bool doneplaying = false;
    bool endGame = false;
    bool raceEnd = false;
    bool endGameAlreadyRan = false;
    public Stopwatch raceTime;

    // points and stuff
    int questionsAnsweredRight = 0;
    int questionsAnsweredWrong = 0;
    int points = 0;
    CarType car;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray = new Sprite[6];
    
    public TMP_Text text, scoreText, questionsText, placementText, timerText;
  
    // Start is called before the first frame update
    void Start()
    {
       accel = PlayerPrefs.GetFloat("acceleration");
       maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
       velocity = maxSpeed;
        spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("carSkin")];
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(2f, 2f);
        raceTime = new Stopwatch();

    }

    // Update is called once per frame
    void Update()
    {

        if (velocity < maxSpeed - 1)
        {
            text.text = "" + (int)velocity * 3.2 + " mph";
            
        }
        else{
            text.text = "" + (int)velocity * 3.2 + " mph" + "\n" + "(MAX SPEED!)";
        }
        if (delayStart > 180)
        {
            if (!raceTime.IsRunning)
            {
                raceTime.Start();
            }
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 12 && !endGame)
            {
                velocity -= accel;
            }
            if (endGame)
            {
                raceTime.Stop();
                if (velocity > 0)
                {
                    velocity = 0;
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
                placementText.text = "You placed: " + "1st!";
                timerText.text = "Time: " + raceTime.Elapsed.TotalSeconds.ToString("#.##") + " seconds";
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
            endGame = true;
            endGameAlreadyRan = true;
            raceEnd = true;
            
        }
        if (doneplaying)
        {
            if (delayChange > 1440)
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
        PlayerPrefs.SetInt("currency", points);
    }
    public void ChangeSprite(){
            spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("CarSkin")];
    }



}
