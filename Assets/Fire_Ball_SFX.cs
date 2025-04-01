using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Fire_Ball_SFX : MonoBehaviour
{
    public AudioSource sfx;
    public void play_sound(){
        sfx.Play(0);
    }
}
