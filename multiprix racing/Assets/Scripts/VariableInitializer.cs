using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetFloat("acceleration", .003f);
        PlayerPrefs.SetFloat("destroyrate", 0f);
        PlayerPrefs.SetFloat("speedincrease", 10);
        PlayerPrefs.SetFloat("maxSpeed", 31f);
        PlayerPrefs.SetInt("carSkin", 1); // i did car skins by numbers, check enum class in player.cs
        Debug.Log(PlayerPrefs.GetInt("phase"));
        Debug.Log(PlayerPrefs.GetFloat("maxSpeed"));
        PlayerPrefs.SetInt("mapnumber", 0);
        PlayerPrefs.SetInt("pricewheels", 300);
        PlayerPrefs.SetInt("priceengine", 450);
        PlayerPrefs.SetInt("pricechassis", 500);
        PlayerPrefs.SetInt("pricewheelsex", 0);
        PlayerPrefs.SetInt("priceengineex", 0);
        PlayerPrefs.SetInt("pricechassisex", 0);
        PlayerPrefs.SetInt("IsPaused", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
