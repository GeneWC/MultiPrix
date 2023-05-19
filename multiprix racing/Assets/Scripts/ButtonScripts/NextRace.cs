using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextRace : MonoBehaviour
{
    public Button toRaceButton;
    void Start() {
        Button btn = toRaceButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick() {
        NetworkManager.Singleton.SceneManager.LoadScene("general_race", LoadSceneMode.Single);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
