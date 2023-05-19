using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_InputWindow : MonoBehaviour
{
    private string input;
    public float increase;
    private TMP_InputField inputField;
    public TextMeshProUGUI question;
    private int answer = 1;
    private GameObject player;
   public GameObject pause;
    public AudioSource CorrectAudioSource, InorrectAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        // read in question from the text field containing the question, and split it to be the numbers, and find the answer of the question.
        question = transform.Find("Question").GetComponent<TextMeshProUGUI>();
        inputField = transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        player = GameObject.Find("Player");
        GenerateNewQuestion();
        inputField.Select();
        inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputField.text.Equals(""))
        {
            if (inputField.text[inputField.text.Length - 1] < 48 || inputField.text[inputField.text.Length - 1] > 57 || inputField.text.Length > 3)
            {
                inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            }
        }

        if (player.GetComponent<Player>().getEndGame())
        {
            inputField.DeactivateInputField();
        }

        if (pause.GetComponent<PauseMenu>().isPaused)
        {
            inputField.text = "";
        }
        
    }



    public void ReadStringInput(string s)
    {
        
        input = s;
        if (player.transform.position.x > 915)
        {
            inputField.DeactivateInputField();
        }
        else
        {
            inputField.ActivateInputField();
        }
        try
        {
            if (Int32.Parse(input) == answer)
            {
                Debug.Log(increase);
                increase = PlayerPrefs.GetFloat("speedincrease");
                player.GetComponent<Player>().setVelocity(increase);
                StartCoroutine(correctQuestion());
                Debug.Log("Correct!");
                GenerateNewQuestion();
                player.GetComponent<Player>().setQuestionsAnswered(true);


            }
            else
            {
                player.GetComponent<Player>().setVelocity(-2);
                StartCoroutine(incorrectQuestion());
            }
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }
        catch (Exception e)
        {
            
        }
        
    }

    public void GenerateNewQuestion()
    {
        System.Random random = new System.Random();
        int num1 = random.Next(1, 12);
        int num2 = random.Next(1, 12);
        answer = num1 * num2;
        question.SetText(num1 + " x " + num2);
        
    }

    IEnumerator incorrectQuestion()
    {
        
        Debug.Log("Incorrect");
        inputField.DeactivateInputField();
        inputField.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;
        player.GetComponent<Player>().setQuestionsAnswered(false);
        inputField.ActivateInputField();
        InorrectAudioSource.Play(0);
    }
    IEnumerator correctQuestion()
    {
        
        Debug.Log("Correct");
        inputField.DeactivateInputField();
        inputField.image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;
        player.GetComponent<Player>().setQuestionsAnswered(true);
        inputField.ActivateInputField();
        CorrectAudioSource.Play(0);
    }
}





