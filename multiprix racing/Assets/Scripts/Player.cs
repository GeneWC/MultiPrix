using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float accel = .01f;
    float velocity = 20;
    int delayStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (delayStart > 180)
        {
            transform.position += new Vector3((velocity - accel) * Time.deltaTime, 0, 0);
            if (velocity - accel > 3)
            {
                accel += 0.025f;
            }
        }
        else
        {
            delayStart++;
        }
        
    }

    public void setVelocity(int v)
    {
        velocity += v;
    }


}
