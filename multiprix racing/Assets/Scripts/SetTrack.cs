using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTrack : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip americaMus, chinaMus, africaMus;
    public GameObject bkg;
    public Sprite americaBkg, chinaBkg, africaBkg;

    // Start is called before the first frame update
    void Start()
    {
        int track = Random.Range(0, 3);
        audio = GetComponent<AudioSource>();

        if (track == 0) // america
        {
            audio.clip = americaMus;
            audio.Play();
            bkg.GetComponent<Image>().sprite = americaBkg;
        }

        if (track == 1) // china
        {
            audio.clip = chinaMus;
            audio.Play();
            bkg.GetComponent<Image>().sprite = chinaBkg;
        }

        if (track == 2) // africa
        {
            audio.clip = africaMus;
            audio.Play();
            bkg.GetComponent<Image>().sprite = africaBkg;
        }
    }

}
