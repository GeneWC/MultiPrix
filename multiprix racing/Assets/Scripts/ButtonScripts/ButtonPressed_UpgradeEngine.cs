using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeEngine : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = PlayerPrefs.GetInt("priceengine");
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
            PlayerPrefs.SetFloat("speedincrease", PlayerPrefs.GetFloat("speedincrease") + 2);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            PlayerPrefs.SetInt("priceengine", PlayerPrefs.GetInt("priceengine") + 100 + (350 * PlayerPrefs.GetInt("priceengineex")));
            PlayerPrefs.SetInt("priceengineex", PlayerPrefs.GetInt("priceengineex") + 1);
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
        pricet1 = PlayerPrefs.GetInt("priceengine");
        if (PlayerPrefs.GetFloat("speedincrease") > 20)
        {
            text.text = "MAX LEVEL";
            pricet1 = 99999999;
        }
        else
        {
            text.text = ("Purchase: " + pricet1);
        }
    
}
}
