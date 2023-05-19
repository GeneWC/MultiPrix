using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostRaceCanvas : MonoBehaviour
{

    [SerializeField] public Player player;
    TextMeshProUGUI score, placement, questionsAnswered;
    private bool updateResults = true;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        placement = GameObject.Find("Placement").GetComponent<TextMeshProUGUI>();
        questionsAnswered = GameObject.Find("QuestionsAnswered").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.raceEnd && updateResults) {
            int questionCount = player.questionsAnsweredRight + player.questionsAnsweredWrong;
            questionsAnswered.text = "Questions Answered: " + player.questionsAnsweredRight + "/" + questionCount ;
            placement.text = "Time: " + (player.timeTaken.Value) + " Seconds!";
            Debug.Log("Percent Accuracy: " + ((player.questionsAnsweredRight + player.questionsAnsweredWrong) != 0 ? (100 * (double)player.questionsAnsweredRight) / questionCount : 0));
            score.text = ("Points earned: " + player.points);
            updateResults = false;
        }
    }
    internal void reset() {
        Start();
        score.text = "";
        placement.text = "";
        questionsAnswered.text = "";
        updateResults = true;
    }
}
