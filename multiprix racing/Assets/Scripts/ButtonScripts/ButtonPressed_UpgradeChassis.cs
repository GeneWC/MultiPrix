using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeChassis : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 450;
    public int n = 1;
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
            Debug.Log("chassis upgraded!");
            PlayerPrefs.SetFloat("maxSpeed", PlayerPrefs.GetFloat("maxSpeed") + 5);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            pricet1 += 100 + (50 * n);
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