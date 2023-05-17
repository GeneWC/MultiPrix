using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeEngine : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 450;
    public int n = 0;
    public AudioSource AudioSource, BadAudio;
    public TMP_Text text;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if (PlayerPrefs.GetInt("currency") >= pricet1)
        {
            AudioSource.Play(0);
            Debug.Log("engine upgraded!");
            PlayerPrefs.SetFloat("increase", PlayerPrefs.GetFloat("increase") + 1);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            pricet1 += 100 + (150 * n);
            n++;
        }
        else
        {
            Debug.Log("NOT ENOUGH MONEY!!!");
            BadAudio.Play(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("increase") > 15)
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
