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
        randomNumber = Random.Range(0, 15);
    }

    // Update is called once per frame
    void Update()
    {
        switch (randomNumber)
        {
            case 0:
            text.text = "WHEELS NOT INCLUDED";
            break;
            case 1:
            text.text = "IS SOMETHING BURNING?";
            break;
            case 2:
            text.text = "2 x 2 = 5?";
            break;
            case 3:
            text.text = "MAAAAAAAAAAAAAATH";
            break;
            case 4:
            text.text = "WHERE ARE MY PAAAANTS"; // do kids even get this reference nowadays
            break;
            case 5:
            text.text = "CAN'T STOP THIS";
            break;
            case 6:
            text.text = "PIT STOPS ARE FOR LOSERS";
            break;
            case 7:
            text.text = "#MATH4LYFE";
            break;
            case 8:
            text.text = "START YOUR MATH ENGINES";
            break;
            case 9:
            text.text = "CAN'T END ON A LOSS";
            break;
            case 10:
            text.text = "JAMES IS BRITISH!";
            break;
            case 11:
            text.text = "ALSO TRY ARCADEMICS!";
            break;
            case 12:
            text.text = "UPGRADES, PEOPLE. UPGRADES!";
            break;
            case 13:
            text.text = "IT'S MONDAY! IT'S TUESDAY!";
            break;
            case 14:
            text.text = "SERGIO, WHAT ARE YOU DOING!?";
            break;
            case 15:
            text.text = "MR MON MON!!!";
            break;
        }
        }
}

