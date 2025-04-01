using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{


    public GameObject[] songs;
    public Slider sliderValue;
    public AudioMixer masterMixer;
    private string current_song = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(sliderValue.value < 0.1f)
        {
            masterMixer.SetFloat("MasterVolume", -100);
        }
        else
        {
            masterMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue.value) * 20);
        }

        //Debug.Log("slider value: " + sliderValue.value);
        
        string scene_name = SceneManager.GetActiveScene().name;

        if (current_song != scene_name){
            HideAllObjects();
            switch (scene_name){
            case "Main_Menu":
                current_song = scene_name;
                songs[0].SetActive(true);
                break;
            case "TheGame":
                current_song = scene_name;
                songs[1].SetActive(true);
                break;
            case "Tutorial":
                current_song = scene_name;
                songs[2].SetActive(true);
                break;
            case "WinScene":
                current_song = scene_name;
                songs[3].SetActive(true);
                break;
        };

        }
        

    }

    void HideAllObjects()
    {
        foreach (GameObject obj in songs)
        {
            obj.SetActive(false);  // Hide each object
        }

        foreach (GameObject obj in songs)
        {
            obj.SetActive(false);  // Hide each object
        }
    }
    
        public void sliderVolume()
    {

    }
}
