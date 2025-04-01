using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] sfx;
    public void play_heal()
    {
        sfx[1].Play();
        
    }

    public void play_expolsion(){
        sfx[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
