using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPressed_UpgradeEngine : MonoBehaviour
{
    public Button yourButton;
    public int pricet1 = 600;
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
        if (PlayerPrefs.GetInt("currency") > pricet1)
        {
            AudioSource.Play(0);
            Debug.Log("engine upgraded!");
            PlayerPrefs.SetFloat("increase", PlayerPrefs.GetFloat("increase") + 2);
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - pricet1);
            pricet1 += 100 + (100 * n);
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
        text.text = ("Engine" + "\n" + "Price: " + pricet1);
    }
}
