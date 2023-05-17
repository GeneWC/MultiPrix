using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCorrectAnimation : MonoBehaviour
{
    private Animation anim;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
