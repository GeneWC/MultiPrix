using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeWheels : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = PlayerPrefs.GetInt("pricewheels");
    public int n = 0;
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
            Debug.Log("wheels upgraded!");
            PlayerPrefs.SetFloat("acceleration", PlayerPrefs.GetFloat("acceleration") - .0005f);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            PlayerPrefs.SetInt("pricewheels", PlayerPrefs.GetInt("pricewheels") + 100 + (150 * PlayerPrefs.GetInt("pricewheelsex")));
            PlayerPrefs.SetInt("pricewheelsex", PlayerPrefs.GetInt("pricewheelsex") + 1);
        }
        else{
            Debug.Log("NOT ENOUGH MONEY!!!");
            BadAudio.Play(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        pricet1 = PlayerPrefs.GetInt("pricewheels");
        if(PlayerPrefs.GetFloat("acceleration") < .002)
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
