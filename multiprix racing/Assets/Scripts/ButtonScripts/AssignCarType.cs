using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignCarType : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Start is called before the first frame update
    public void TaskOnClick() {
        switch (yourButton.name)
        {
            case "Blue":
                PlayerPrefs.SetInt("carSkin", 1);
                break;
            case "Red":
                PlayerPrefs.SetInt("carSkin", 2);
                break;
            case "Green":
                PlayerPrefs.SetInt("carSkin", 3);
                break;
            case "Pink":
                PlayerPrefs.SetInt("carSkin", 4);
                break;
            case "Black":
                PlayerPrefs.SetInt("carSkin", 5);
                break;
            case "White":
                PlayerPrefs.SetInt("carSkin", 6);
                break;
            default:
                PlayerPrefs.SetInt("carSkin", -1);
                break;
        }

        Debug.Log(PlayerPrefs.GetInt("carSkin"));

    }
}
