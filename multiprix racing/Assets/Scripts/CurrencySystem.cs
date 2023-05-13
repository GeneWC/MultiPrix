using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    public int currency;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("phase", 1);
        currency = PlayerPrefs.GetInt("currency");
    }

    // Update is called once per frame
    void Update()
    {
        currency = PlayerPrefs.GetInt("currency");
        Debug.Log(currency);
        text.text = "Current Balance: " + currency;
    }
}
