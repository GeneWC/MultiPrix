using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPressed : MonoBehaviour
{
    string[] mapnames = { "africa_race", "america_race", "china_race", "Mazda" };
    public Button yourButton;
    public AudioSource AudioSource;
    int randomNumber;
   
       
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 3);
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        SceneManager.LoadScene(mapnames[randomNumber]);
        AudioSource.Play(0);
        Destroy(GameObject.Find("Main Title Track"));
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
