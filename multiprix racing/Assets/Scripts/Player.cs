using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float accel = .01f;
    float velocity = 20;
    int delayStart = 0;
    bool endGame = false;
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
                accel += 0.01f;
            }
        }
        else
        {
            delayStart++;
        }

        if (transform.position.x > 10000)
        {
            accel = 1f;
            endGame = true;
            if (velocity < 0)
            {
                velocity = 0;
                accel = 0f;
            }
        }
        
    }

    public void setVelocity(int v)
    {
        velocity += v;
    }

    public bool getEndGame()
    {
        return endGame;
    }

}
