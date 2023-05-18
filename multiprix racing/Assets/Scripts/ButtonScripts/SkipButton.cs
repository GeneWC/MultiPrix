using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public Button yourButton;
    //public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
         //AudioSource.Play(0);
        PlayerPrefs.SetInt("mapnumber", PlayerPrefs.GetInt("mapnumber") + 1);
        PlayerPrefs.SetFloat("destroyrate", (float)(PlayerPrefs.GetInt("destroyrate") + .003));
        SceneManager.LoadScene("Briefing");

       
	}

    // Update is called once per frame
    void Update()
    {
        
        
    }
}