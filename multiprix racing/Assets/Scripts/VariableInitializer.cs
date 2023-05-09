using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetFloat("acceleration", .01f);
        PlayerPrefs.SetInt("phase", 0);
        PlayerPrefs.SetInt("velocity", 30);
        Debug.Log(PlayerPrefs.GetInt("phase"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
