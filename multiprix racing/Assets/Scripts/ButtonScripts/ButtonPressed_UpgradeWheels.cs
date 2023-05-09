using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed_UpgradeWheels : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 300;
    public AudioSource AudioSource, BadAudio;
    
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        if(PlayerPrefs.GetInt("currency") > pricet1){
            AudioSource.Play(0);
            Debug.Log("wheels upgraded!");
            PlayerPrefs.SetFloat("acceleration", PlayerPrefs.GetFloat("acceleration") - .003f);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
        }
        else{
            Debug.Log("NOT ENOUGH MONEY!!!");
            BadAudio.Play(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
