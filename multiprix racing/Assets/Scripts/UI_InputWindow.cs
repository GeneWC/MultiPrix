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
    // Start is called before the first frame update
    void Start()
    {
        // read in question from the text field containing the question, and split it to be the numbers, and find the answer of the question.
        question = transform.Find("Question").GetComponent<TextMeshProUGUI>();
        inputField = transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        GenerateNewQuestion();
        inputField.Select();
        inputField.ActivateInputField();
    }
    Player getPlayer(){
        GameObject player = GameObject.Find("Player");
        return player != null ? player.GetComponent<Player>() : null;
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
        Player player = getPlayer();
        if (player != null && player.getEndGame())
        {
            inputField.DeactivateInputField();
        }
        
    }



    public void ReadStringInput(string s)
    {
        
        input = s;
        try {
            
            if (Int32.Parse(input) == answer) {
        
                Debug.Log("Correct!");
                GenerateNewQuestion();
                Player player = getPlayer();
                if(player != null)
                    player.setQuestionsAnswered(true);
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
        catch(Exception ex) {
        }
    }

    public void GenerateNewQuestion()
    {
        System.Random random = new System.Random();
        int num1 = random.Next(1, 12);
        int num2 = random.Next(1, 12);
        answer = num1 * num2;
        question.SetText(num1 + " x " + num2);
        Player player = getPlayer();
        if(player != null)
            player.setVelocity(5);
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
        Player player = getPlayer();
        if(player != null)
            player.setQuestionsAnswered(false);
        inputField.ActivateInputField();
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
        Player player = getPlayer();
        if(player != null)
            player.setQuestionsAnswered(false);
        inputField.ActivateInputField();
    }
}





