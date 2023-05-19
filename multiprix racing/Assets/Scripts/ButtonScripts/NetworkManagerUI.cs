using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System;
using Cinemachine;
using Unity.Netcode.Transports.UTP;
using System.Net;
using UnityEngine.Events;

public class NetworkManagerUI : MonoBehaviour {
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private GameObject myPrefab;
    [SerializeField] private GameObject startRaceButton;
    [SerializeField] private GameObject nextRaceButton;
    private bool clientStarted = false;
    private void Awake() {
        hostBtn.onClick.AddListener(() => {
            GameObject.Find("NetworkManager").GetComponent<ExampleNetworkDiscovery>().StopDiscovery();
            Player.playerCounter = 1;
            StartRace.endGame = false;
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.OnLoadComplete += addButton;
            NetworkManager.Singleton.SceneManager.OnLoadComplete += SetPlayerPosition;
            NetworkManager.Singleton.SceneManager.LoadScene("character_select", LoadSceneMode.Single);
            
            Destroy(GameObject.Find("Main Title Track"));

        });

        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            NetworkManager.Singleton.SceneManager.OnLoadComplete += SetPlayerPosition;
            Destroy(GameObject.Find("Main Title Track"));
        });
    }

    private void addButton(ulong clientId, string sceneName, LoadSceneMode loadSceneMode) {
        if (sceneName.Equals("character_select") && NetworkManager.Singleton.LocalClientId == clientId) {
            GameObject startButton = Instantiate(startRaceButton, new Vector3(1660,875,0), Quaternion.identity);
            GameObject characterScreen = GameObject.Find("CharacterScreen");
            startButton.transform.parent = characterScreen.transform;
        }
        if (sceneName.Equals("Upgrades") && NetworkManager.Singleton.LocalClientId == clientId) {
            GameObject nextRace = Instantiate(nextRaceButton, new Vector3(275, 950, 0), Quaternion.identity);
            GameObject characterScreen = GameObject.Find("ScreenUpgrades");
            nextRace.transform.parent = characterScreen.transform;
        }
    }

    private void SetPlayerPosition(ulong clientId, string sceneName, LoadSceneMode loadSceneMode) {
         if (sceneName.Equals("general_race") && NetworkManager.Singleton.LocalClientId == clientId) {
            Player p = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject().GetComponent<Player>();
            p.Initalize();
            GameObject.Find("PostRaceCanvas").GetComponent<PostRaceCanvas>().reset();
         }
     }
    void Update() {
        if (!clientStarted) {
            ExampleNetworkDiscovery nd = GameObject.Find("NetworkManager").GetComponent<ExampleNetworkDiscovery>();
            nd.OnServerFound.AddListener(OnServerFound);
            nd.StartClient();
            nd.ClientBroadcast(new DiscoveryBroadcastData());
            clientStarted = true;
        }
    }

    void OnServerFound(IPEndPoint sender, DiscoveryResponseData response) {
        UnityTransport transport = (UnityTransport)NetworkManager.Singleton.NetworkConfig.NetworkTransport;
        String ipaddress = sender.Address.ToString();
        transport.SetConnectionData(ipaddress, 7777);
    }
}