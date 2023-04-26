using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    private string input;
    private TMP_InputField inputField;
    public TextMeshProUGUI question;
    private int answer = 1;
    private GameObject player;
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
            if (inputField.text[inputField.text.Length - 1] < 48 || inputField.text[inputField.text.Length - 1] > 57 || inputField.text.Length > 3) // makes sure the input in the text field is valid
            {
                inputField.text = inputField.text.Substring(0, inputField.text.Length - 1); // delete text if input isn't valid
            }
        }

        if (player.GetComponent<Player>().getEndGame()) // game has ended, disable textField
        {
            inputField.DeactivateInputField();
        }
        
    }



    public void ReadStringInput(string s)
    {
        
        input = s;

        if (Int32.Parse(input) == answer)
        {
            Debug.Log("Correct!");
            GenerateNewQuestion();
            player.GetComponent<Player>().setQuestionsAnswered(true);

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
        player.GetComponent<Player>().setVelocity(5);
    }

    IEnumerator incorrectQuestion() // simultaneous routine that runs when a questions is wrong
    {
        Debug.Log("Incorrect");
        inputField.DeactivateInputField();

        // flash the input screen
        inputField.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        inputField.image.color = Color.white;

        // add 1 to incorrect answers
        player.GetComponent<Player>().setQuestionsAnswered(false);
        inputField.ActivateInputField();
    }
}





