using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeChassis : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 550;
    public int n = 1;
    public AudioSource AudioSource, BadAudio;
    public TMP_Text text;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        if(PlayerPrefs.GetInt("currency") >= pricet1){
            AudioSource.Play(0);
            Debug.Log("chassis upgraded!");
            PlayerPrefs.SetFloat("maxSpeed", PlayerPrefs.GetFloat("maxSpeed") + 4);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            pricet1 += 100 + (50 * n);
            n++;
        }
        else{
            Debug.Log("NOT ENOUGH MONEY!!!");
            BadAudio.Play(0);
            text.color = new Color(255, 0, 0);
            text.color = new Color(255, 255, 255);
            text.color = new Color(255, 0, 0);
            text.color = new Color(255, 255, 255);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("maxSpeed") > 50)
        {
            text.text = "MAX LEVEL";
            pricet1 = 999999999;
        }
        else
        {
            text.text = ("Purchase: " + pricet1);
        }

    }
}
