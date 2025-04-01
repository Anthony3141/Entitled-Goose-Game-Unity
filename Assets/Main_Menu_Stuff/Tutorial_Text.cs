using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial_Text : MonoBehaviour
{
    public Button myButton;
    public GameObject[] objectsToToggle;  // Array of objects to toggle
    public GameObject[] textToToggle;
    private int clickCount = 0;

    void Start()
    {
        // Add the listener to the button's onClick event
        myButton.onClick.AddListener(OnButtonClick);
        HideAllObjects();

        objectsToToggle[clickCount].SetActive(true);
        textToToggle[clickCount].SetActive(true);
    }

    void OnButtonClick()
    {
        if(clickCount == 8){
            SceneManager.LoadScene(2);
        }
        else {
            // Hide all objects first
            HideAllObjects();

            // Show the current object
            objectsToToggle[clickCount].SetActive(true);
            textToToggle[clickCount].SetActive(true);

        
            // Increment the click count
            clickCount++;
        }
    }

    void HideAllObjects()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);  // Hide each object
        }

        foreach (GameObject obj in textToToggle)
        {
            obj.SetActive(false);  // Hide each object
        }
    }
}
