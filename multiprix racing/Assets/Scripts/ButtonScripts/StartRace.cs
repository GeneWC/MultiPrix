using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class StartRace : MonoBehaviour
{
    public Button startRaceButton;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startRaceButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick() {
        foreach(var no in NetworkManager.Singleton.ConnectedClients) {
            no.Value.PlayerObject.GetComponent<Player>().started.Value = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
