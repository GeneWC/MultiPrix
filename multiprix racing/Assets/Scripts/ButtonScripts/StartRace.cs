using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class StartRace : MonoBehaviour
{
    public Button startRaceButton;
    public static bool endGame = false;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startRaceButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {     
        foreach (var no in NetworkManager.Singleton.ConnectedClients)
        {
            Player p = no.Value.PlayerObject.GetComponent<Player>();
            p.started.Value = true;
        }
        StartCoroutine("checkAllPlayerFinish");
    }

    private IEnumerator checkAllPlayerFinish() {
        bool allPlayersFinished = false;
        while (!allPlayersFinished) {
            bool checkPlayersFinish = true;
            foreach (var no in NetworkManager.Singleton.ConnectedClients) {
                Player p = no.Value.PlayerObject.GetComponent<Player>();
                checkPlayersFinish &= p.transform.position.x >= 100;
            }
            allPlayersFinished = checkPlayersFinish;
            yield return new WaitForSecondsRealtime(1);
        }
        yield return new WaitForSecondsRealtime(3);
        if (endGame) {
            NetworkManager.Singleton.SceneManager.LoadScene("Game End", LoadSceneMode.Single);
        } else {
            NetworkManager.Singleton.SceneManager.LoadScene("Upgrades", LoadSceneMode.Single);
            endGame = true;
        }
        
    }
}