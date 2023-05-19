using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
public class AssignCarType : MonoBehaviour
{
    public Button yourButton;
    
    [SerializeField] private GameObject myPrefab;
    private void Start()
    {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Start is called before the first frame update
    public void TaskOnClick() {
        string carName = yourButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        if (yourButton.name.Equals("Blue"))
        {
            
            PlayerPrefs.SetInt("carSkin", 0);
        }
        if (yourButton.name.Equals("Red"))
        {
            PlayerPrefs.SetInt("carSkin", 1);
        }
        if (yourButton.name.Equals("Green"))
        {
            PlayerPrefs.SetInt("carSkin", 2);
        }
        if (yourButton.name.Equals("Pink"))
        {
            PlayerPrefs.SetInt("carSkin", 3);
        }
        if (yourButton.name.Equals("Black"))
        {
            PlayerPrefs.SetInt("carSkin", 4);
        }
        if (yourButton.name.Equals("White")) 
        {
            PlayerPrefs.SetInt("carSkin", 5);
        }
        GameObject.Find("TopText").GetComponent<TMPro.TextMeshProUGUI>().text = carName;
        Destroy(GameObject.Find("Cars"));
        Destroy(GameObject.Find("Buttons"));


        //MOVED TO ToRace
        /* Destroy(GameObject.Find("Main Title Track"));
        SceneManager.LoadScene(mapName); */

        Debug.Log(PlayerPrefs.GetInt("carSkin"));

    }
}
