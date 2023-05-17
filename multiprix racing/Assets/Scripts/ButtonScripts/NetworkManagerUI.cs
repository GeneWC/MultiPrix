using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System;
using Cinemachine;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;

    private void Awake()
    {
        hostBtn.onClick.AddListener(() => {

            NetworkManager.Singleton.StartHost();
            NetworkSceneManager nsm = NetworkManager.Singleton.SceneManager;
            nsm.OnLoadComplete += SetPlayerPosition;
            nsm.LoadScene("character_select", UnityEngine.SceneManagement.LoadSceneMode.Single);
            Destroy(GameObject.Find("Main Title Track"));

        });

        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            Destroy(GameObject.Find("Main Title Track"));
        });
    }

    private void SetPlayerPosition(ulong clientId, string sceneName, LoadSceneMode loadSceneMode)
    {
        if (sceneName.Equals("character_select") && NetworkManager.Singleton.IsHost)
        {
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
    }
}