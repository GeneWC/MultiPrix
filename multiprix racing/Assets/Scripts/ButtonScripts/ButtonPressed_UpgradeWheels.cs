using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeWheels : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 300;
    public int n = 0;
    public AudioSource AudioSource, BadAudio;
    public TMP_Text text;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        if(PlayerPrefs.GetInt("currency") > pricet1){
            AudioSource.Play(0);
            Debug.Log("wheels upgraded!");
            PlayerPrefs.SetFloat("acceleration", PlayerPrefs.GetFloat("acceleration") - .001f);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            pricet1 += 100 + (100 * n);
            n++;
        }
        else{
            Debug.Log("NOT ENOUGH MONEY!!!");
            BadAudio.Play(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        text.text = ("Purchase: " + pricet1);
    }
}
