using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class ToRace : MonoBehaviour
{
    // Start is called before the first frame update
    public Button toRaceButton;
    void Start()
    {
        Button btn = toRaceButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Destroy(GameObject.Find("Main Title Track"));
        SceneManager.LoadScene("general_race");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
