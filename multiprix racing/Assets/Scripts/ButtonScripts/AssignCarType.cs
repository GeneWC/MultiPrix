using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssignCarType : MonoBehaviour
{
    public Button yourButton;
    int randomNumber;
    string[] mapnames = { "africa_race", "america_race", "china_race", "Mazda" };

    private void Start()
    {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        randomNumber = Random.Range(0, 3);
    }

    // Start is called before the first frame update
    public void TaskOnClick() {
        switch (yourButton.name)
        {
            case "Blue":
                PlayerPrefs.SetInt("carSkin", 0);
                break;
            case "Red":
                PlayerPrefs.SetInt("carSkin", 1);
                break;
            case "Green":
                PlayerPrefs.SetInt("carSkin", 2);
                break;
            case "Pink":
                PlayerPrefs.SetInt("carSkin", 3);
                break;
            case "Black":
                PlayerPrefs.SetInt("carSkin", 4);
                break;
            case "White":
                PlayerPrefs.SetInt("carSkin", 5);
                break;
            default:
                PlayerPrefs.SetInt("carSkin", -1);
                break;
        }
         Destroy(GameObject.Find("Main Title Track"));
        SceneManager.LoadScene(mapnames[randomNumber]);

        Debug.Log(PlayerPrefs.GetInt("carSkin"));

    }
}
