using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BriefingManager : MonoBehaviour
{
    public TMP_Text text, difficultyText;
    int track;
    // Start is called before the first frame update
    void Start()
    {
        track = PlayerPrefs.GetInt("mapnumber");
    }

    // Update is called once per frame
    void Update()
    {
         if (track == 0) // america
        {
            text.text = "Next Race: America";
            difficultyText.text = "Difficulty: Easy";
        }

        if (track == 1) // china
        {
            text.text = "Next Race: China";
            difficultyText.text = "Difficulty: Medium";
        }

        if (track == 2) // africa
        {
            text.text = "Next Race: Africa";
            difficultyText.text = "Difficulty: Hard";
        }
        if (track == 3) // india
        {
            text.text = "Next Race: India";
            difficultyText.text = "Difficulty: Ultimate";
        }
    }
    }

