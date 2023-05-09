using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currency", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
