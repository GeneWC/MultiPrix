using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class UI_InputWindow : MonoBehaviour
{
    private string input;
    private Animation anim;
    private TMP_InputField inputField;
    public TextMeshProUGUI question;
    private int answer = 1;
    public Player player;
    public AudioSource CorrectAudioSource, InorrectAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        // read in question from the text field containing the question, and split it to be the numbers, and find the answer of the question.
        question = transform.Find("Question").GetComponent<TextMeshProUGUI>();
        inputField = transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        //player = GameObject.Find("Player");
        GenerateNewQuestion();
        inputField.Select();
        inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) { return; }


        GameObject mph = GameObject.Find("MPH");

        String mphText = "" + (int)player.velocity + " mph";
        if (player.velocity >= player.maxSpeed - 1) {
            mphText += "\n" + "(MAX SPEED!)";
        }
        mph.GetComponent<TextMeshProUGUI>().text = mphText;
        if (!inputField.text.Equals("")) {
            if (inputField.text[inputField.text.Length - 1] < 48 || inputField.text[inputField.text.Length - 1] > 57 || inputField.text.Length > 3) {
                inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            }
        }
        if (player.GetComponent<Player>().getEndGame()) {
            inputField.DeactivateInputField();
        }

    }



    public void ReadStringInput(string s)
    {
        if (player == null || s == null || s.Equals("")) { return; }

        input = s;

        if (Int32.Parse(input) == answer)
        {
            Debug.Log("Correct!");
            GenerateNewQuestion();
            if (player != null) {
                player.GetComponent<Player>().setQuestionsAnswered(true);
                player.GetComponent<Player>().setVelocity(3);
            }
  
             StartCoroutine(correctQuestion());
            
        }
        else
        {
            StartCoroutine(incorrectQuestion());
        }
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void GenerateNewQuestion()
    {
        System.Random random = new System.Random();
        int num1 = random.Next(1, 12);
        int num2 = random.Next(1, 12);
        answer = num1 * num2;
        question.SetText(num1 + " x " + num2);
        if (player != null) {
            player.GetComponent<Player>().setVelocity(PlayerPrefs.GetFloat("increase")/5f);
        }
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
        if (player != null) {
            player.GetComponent<Player>().setQuestionsAnswered(false);
        }
        inputField.ActivateInputField();
        //InorrectAudioSource.Play(0);
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
        if (player != null) {
            player.GetComponent<Player>().setQuestionsAnswered(true);
        }
        inputField.ActivateInputField();
        //CorrectAudioSource.Play(0);
    }
}





