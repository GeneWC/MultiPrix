using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetFloat("acceleration", .005f);
        PlayerPrefs.SetInt("phase", 0);
        PlayerPrefs.SetFloat("maxSpeed", 31f);
        PlayerPrefs.SetFloat("increase", 4f);
        Debug.Log(PlayerPrefs.GetInt("phase"));
        Debug.Log(PlayerPrefs.GetFloat("maxSpeed"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
