using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System;
using Cinemachine;

public class NetworkManagerUI : MonoBehaviour {
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private GameObject myPrefab;
    private void Awake() {
        hostBtn.onClick.AddListener(() => {

            NetworkManager.Singleton.StartHost();
            SceneManager.activeSceneChanged += SetPlayerPosition;
            SceneManager.LoadScene("character_select");
            Destroy(GameObject.Find("Main Title Track"));

        });

        clientBtn.onClick.AddListener(() => {
            
            SceneManager.LoadScene("character_select");
            Destroy(GameObject.Find("Main Title Track"));
        });
    }

    private void SetPlayerPosition(Scene currentScene, Scene nextScene) {
        if (nextScene.name.Equals("general_race")) {
            GameObject player = Instantiate(myPrefab, Vector3.zero, Quaternion.identity);
            GetComponent<NetworkObject>().Spawn(false);
            /*NetworkObject o = NetworkManager.Singleton.LocalClient.PlayerObject;
             Player p = o.GetComponent<Player>(); */

        }
    }

    /* private void SetPlayerPosition(ulong clientId, string sceneName, LoadSceneMode loadSceneMode) {
         if (sceneName.Equals("general_race") && NetworkManager.Singleton.IsHost) {
             NetworkObject o = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
             Player p = o.GetComponent<Player>();
             GameObject followPlayerCameraObject = GameObject.Find("CM vcam1");
             CinemachineVirtualCamera followPlayerCamera = followPlayerCameraObject.GetComponent<CinemachineVirtualCamera>();
             followPlayerCamera.Follow = p.transform;
             var transposer = followPlayerCamera.GetCinemachineComponent<CinemachineTransposer>();
             transposer.m_FollowOffset = new Vector3(7.63f, (-2.8f + (p.m_player - 1) * 1.5f), -10.6f);
             GameObject inputFieldObject = GameObject.Find("UI_InputWindow");
             inputFieldObject.GetComponent<UI_InputWindow>().player = p;
         }
     }*/
}