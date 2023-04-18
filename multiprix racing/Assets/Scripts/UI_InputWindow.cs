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
        string qText = question.text;
        string[] numsString = qText.Split(" x ");

        for (int i = 0; i < numsString.Length; i++)
        {
            int curr = Int32.Parse(numsString[i]);
            answer *= curr;
        }
        Debug.Log(answer);
        inputField.Select();
        inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ReadStringInput(string s)
    {
        System.Random random = new System.Random();
        input = s;

        if (Int32.Parse(input) == answer)
        {
            Debug.Log("Correct!");
            int num1 = random.Next(1, 12);
            int num2 = random.Next(1, 12);
            answer = num1 * num2;
            question.SetText(num1 + " x " + num2);
            player.GetComponent<Player>().setVelocity(5);
        }
        else
        {
            Debug.Log("Incorrect");
        }
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }
}



