using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Unity.Netcode;
using Cinemachine;
public class Player : NetworkBehaviour
{
    float waittochangetomenu = 0f;
    bool gameLost;
    float accel;
    public AudioSource audio;
    private Animation anim;
    float seconds;
    float addseconds;
    public float maxSpeed;
    public float velocity;
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
    
    public TMP_Text text, scoreText, questionsText, placementText;

    //network varibles
    public static int playerCounter = 1;
    public int m_player = 1;
    public NetworkVariable<bool> started = new NetworkVariable<bool>(false);

    // Start is called before the first frame update
    /* void Start()
    {
        gameLost = false;
        addseconds = 0f;
        seconds = 0f;
        anim = gameObject.GetComponent<Animation>();
       accel = PlayerPrefs.GetFloat("acceleration");
       maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
       velocity = maxSpeed/3;
        Debug.Log("Skin: " + PlayerPrefs.GetInt("carSkin"));
        spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("carSkin")];
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(2f, 2f);

    } */
    public override void OnDestroy() {
        base.OnDestroy();
    }
    public override void OnNetworkSpawn() {
        base.OnNetworkSpawn();
        accel = PlayerPrefs.GetFloat("acceleration");
        maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
        velocity = maxSpeed;
        m_player = playerCounter++;
        
        if (!IsOwner) { return; }
        if (IsServer) { return; }
        /* GameObject followPlayerCameraObject = GameObject.Find("CM vcam1");
        CinemachineVirtualCamera followPlayerCamera = followPlayerCameraObject.GetComponent<CinemachineVirtualCamera>();
        followPlayerCamera.Follow = transform;
        var transposer = followPlayerCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(7.63f, (-2.8f + (m_player - 1) * 1.5f), -10.6f);
        GameObject inputFieldObject = GameObject.Find("UI_InputWindow");
        inputFieldObject.GetComponent<UI_InputWindow>().player = this; */

    }
    void Initalize() {
        transform.position = new Vector3(-7.63f, (4.5f - (m_player * 1.5f)), 0);
        GameObject followPlayerCameraObject = GameObject.Find("CM vcam1");
        CinemachineVirtualCamera followPlayerCamera = followPlayerCameraObject.GetComponent<CinemachineVirtualCamera>();
        followPlayerCamera.Follow = transform;
        var transposer = followPlayerCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(7.63f, (-2.8f + (m_player - 1) * 1.5f), -10.6f);
        GameObject inputFieldObject = GameObject.Find("UI_InputWindow");
        inputFieldObject.GetComponent<UI_InputWindow>().player = this;
    }
    // Update is called once per frame
    void Update()
    {
     
        
        if (started.Value)
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
                    velocity = 0;
                    audio.Play(0);
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
                if (gameLost)
                {
                    velocity = 0;
                    questionsText.text = "GAME OVER";
                    doneplaying = true;
                }
                else
                {
                    questionsText.text = "Questions Answered: " + questionsAnsweredRight + "/" + (questionsAnsweredRight + questionsAnsweredWrong);
                    placementText.text = "Time: " + seconds + " Seconds!";
                    Debug.Log("Percent Accuracy: " + (100 * (double)questionsAnsweredRight) / (questionsAnsweredRight + questionsAnsweredWrong));
                    doneplaying = true;
                    calculatePoints();
                }
                    
                
                   
                }
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
                if (gameLost == false)
                {
                    if (PlayerPrefs.GetInt("phase") == 0)
                    {

                        SceneManager.LoadScene("Upgrades");
                    }
                    if (PlayerPrefs.GetInt("phase") == 1)
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
    public void ChangeSprite(){
            spriteRenderer.sprite = spriteArray[PlayerPrefs.GetInt("CarSkin")];
    }



}
