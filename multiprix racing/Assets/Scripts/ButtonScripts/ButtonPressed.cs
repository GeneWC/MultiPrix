using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPressed : MonoBehaviour
{
    
    public Button yourButton;
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
       
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
		SceneManager.LoadScene("africa_race");
        AudioSource.Play(0);
        Destroy(GameObject.Find("Main Title Track"));
        
	}

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
