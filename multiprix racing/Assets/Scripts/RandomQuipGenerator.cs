using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomQuipGenerator : MonoBehaviour
{
    int randomNumber;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        switch (randomNumber)
        {
            case 0:
            Debug.Log("1 Quote");
            text.text = "WHEELS NOT INCLUDED";
            break;
            case 1:
            Debug.Log("2 Quote");
            text.text = "IS SOMETHING BURNING?";
            break;
            case 2:
            Debug.Log("3 Quote");
            text.text = "2 x 2 = 5?";
            break;
            case 3:
            Debug.Log("4 Quote");
            text.text = "MAAAAAAAAAAAAAATH";
            break;
            case 4:
            Debug.Log("5 Quote");
            text.text = "WHERE ARE MY PANTS";
            break;
            case 5:
            Debug.Log("6 Quote");
            text.text = "CAN'T STOP THIS";
            break;
            case 6:
            Debug.Log("7 Quote");
            text.text = "PIT STOPS ARE FOR LOSERS";
            break;
            case 7:
            Debug.Log("8 Quote");
            text.text = "#MATH4LYFE";
            break;
            case 8:
            Debug.Log("9 Quote");
            text.text = "START YOUR MATH ENGINES";
            break;
            case 9:
            Debug.Log("10 Quote");
            text.text = "CAN'T END ON A LOSS";
            break;
            
        }
        }
}

