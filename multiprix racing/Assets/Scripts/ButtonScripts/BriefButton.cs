using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BriefButton : MonoBehaviour
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
        
		SceneManager.LoadScene("general_race");

       
	}

    // Update is called once per frame
    void Update()
    {
        
        
    }
}