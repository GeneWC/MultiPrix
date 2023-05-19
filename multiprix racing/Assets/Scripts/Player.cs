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
   
    bool gameLost;
    float accel;
    float destroyrate;
    float endingvelocity = 100;
    public AudioSource audio;
    private Animation anim;
    public Stopwatch timer;
    float difficulty;
    float maxSpeed;
    float velocity;
    double fixeddestroyrate;
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
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite[] spriteArray = new Sprite[6];

    public TMP_InputField inputField;
    public TMP_Text text, scoreText, questionsText, placementText;
  
    // Start is called before the first frame update
    void Start()
    {
      
        fixeddestroyrate = fixeddestroyrate + .1;
        gameLost = false;
        timer = new Stopwatch();
        anim = gameObject.GetComponent<Animation>();
       accel = PlayerPrefs.GetFloat("acceleration");
       maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
       velocity = maxSpeed/3;
        spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("carSkin")];
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(2f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        difficulty = PlayerPrefs.GetFloat("difficultymult");
        destroyrate = PlayerPrefs.GetFloat("destroyrate");
        
        if (velocity < 1 && !endGame && !endGameAlreadyRan)
        {
            endGame = true;
            endingvelocity = 0;

        }
        else if (velocity <= 5)
        {
            text.text = "" + (int)velocity * 3.2 + " mph" + ": HURRY UP!!!";
        }
        else if (velocity < maxSpeed - 1)
        {
            text.text = "" + (int)velocity * 3.2 + " mph";
            
        }
        
        else
            {
            text.text = "" + (int)velocity * 3.2 + " mph" + "\n" + "(MAX SPEED!)";
        }
        if (delayStart > 150)
        {
            if (velocity < 0) velocity = 0;
            inputField.ActivateInputField();
            if (!timer.IsRunning)
            {
                timer.Start();
            }
            transform.position += new Vector3((velocity) * Time.deltaTime, 0, 0);
            if (velocity > 0 && !endGame)
            {
                if(PlayerPrefs.GetInt("IsPaused") == 0){
                velocity -= (accel * difficulty);
                }
                else{
                    
                }
            }
            if (endGame)
            {
                timer.Stop();
                inputField.DeactivateInputField();
                if(endingvelocity < 1){
                    gameLost = true;
                }
                else{
                    gameLost = false;
                }
                if (gameLost)
                {
                    velocity = 0;
                    questionsText.text = "GAME OVER";
                    doneplaying = true;
                }
                else
                {
                    questionsText.text = "Questions Answered: " + questionsAnsweredRight + "/" + (questionsAnsweredRight + questionsAnsweredWrong);
                    placementText.text = "Time: " + timer.Elapsed.TotalSeconds.ToString("#.##") + " Seconds!";

                    doneplaying = true;
                    calculatePoints();
                }
                
                if (velocity > 0)
                {
                    velocity = 0;
                    if(gameLost){}
                    else{
                    audio.Play(0);
                    }
                }
                else
                {
                    velocity = 0;
                    
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

        if (transform.position.x > 915 && !endGameAlreadyRan)
        {
            accel = .1f;
            endingvelocity = 100;
            endGame = true;
            endGameAlreadyRan = true;
            raceEnd = true;
            
        }
        if (doneplaying)
        {
            if (delayChange > 1440)
            {
                if (gameLost == false)
                {
                    if (PlayerPrefs.GetInt("mapnumber") <= 2)
                    {

                        SceneManager.LoadScene("Upgrades");
                    }
                    if (PlayerPrefs.GetInt("mapnumber") == 3)
                    {

                        SceneManager.LoadScene("Game End");
                    }
                }
                else
                {
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
        scoreText.text = ("Points earned: " + points + " x " + (PlayerPrefs.GetInt("mapnumber") + 1) + " Marathon Bonus!");
        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") + (points * (PlayerPrefs.GetInt("mapnumber") + 1)));
    }
    public void ChangeSprite(){
            spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("CarSkin")];
    }



}
